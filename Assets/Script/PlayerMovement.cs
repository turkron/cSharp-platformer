using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

		// Use this for initialization
		public float playerSpeed = 0.01f; 
		public float maxPlayerSpeed = 0.5f;
		public float friction = 0.01f;
		public float acceletation = 0.01f;

		public float playerUpSpeed = 0.0f;
		public float gravity;
		public float maxFallingSpeed = -1f;

		public bool onGround = false;

		public bool ableToMoveLeft = true;
		public bool ableToMoveRight = true;
		public bool ableToJump = true;
		public bool ableToClimb = false;

		public string climbWhat = "null";
		public bool activateClimbEdge = false;
		public float edgeTimer = 0f;


		public float numOfJumps = 1;
		public float maxJumps = 1;

		public float lastFrameYPos;

		public string JumpStatus;
		public string grabStatus;
		public bool leftGrab = false;
		public bool rightGrab = false;

		public bool meleeAttack = false;
		public int attackFrame = 0;
		public bool rangedAttack = false;

		public GameObject bulletPrefab;

		public GameObject respawnPoint;

		void Start ()
		{
				lastFrameYPos = this.transform.position.y;
	
		}
	
		// Update is called once per frame

		void Update ()
		{
		
				if (!onGround && !leftGrab && !rightGrab) {
				
						this.GetComponent<Rigidbody2D> ().gravityScale = gravity;

				}
				if (this.transform.position.y < lastFrameYPos) {
						JumpStatus = "Falling";
				}
				if (this.transform.position.y > lastFrameYPos) {
						JumpStatus = "Jumping";
				}
				if (this.transform.position.y == lastFrameYPos) {
						JumpStatus = "onGround";
				}
				this.transform.Translate (Vector2.right * playerSpeed);
				//this.transform.Translate (Vector2.up * playerUpSpeed);

				if (playerSpeed > 0) {
						playerSpeed -= friction;
				}
				if (playerSpeed < 0) {
						playerSpeed += friction;
				}
		
				if (playerSpeed < 0.01f && playerSpeed > -0.01f) {
						playerSpeed = 0;
				}
				if (playerSpeed > maxPlayerSpeed) {
						playerSpeed = maxPlayerSpeed;	
				}
				if (playerSpeed < -maxPlayerSpeed) {
						playerSpeed = -maxPlayerSpeed;	
				}
		
//		if (onGround == false && playerUpSpeed > maxFallingSpeed) {
//			playerUpSpeed -= gravity;
//		}

				if (onGround == true) {
						numOfJumps = 2;
				}

	
				if (Input.GetKey (KeyCode.D)) {
						if (ableToMoveRight == true) {
								playerSpeed += 0.025f;
								//transform.eulerAngles = new Vector2(0,0); 
						}

				}

				if (Input.GetKey (KeyCode.A)) {
						if (ableToMoveLeft == true) {
								playerSpeed -= 0.025f;
								//transform.eulerAngles = new Vector2(0, 180); 
						}
			
				}

				if (Input.GetKeyDown (KeyCode.W)) {
						if (ableToJump == true) {
								if (numOfJumps > 0) {
										this.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
										this.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerUpSpeed);
										numOfJumps -= 1;
								} else {
										ableToJump = false;
								}
						}

						if (ableToClimb == true) {
								activateClimbEdge = true;
						}
				}

				if (Input.GetKeyDown (KeyCode.S)) {
						if (ableToClimb == true) {
								this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = gravity;
								ableToClimb = false;
						}
						if (leftGrab == true || rightGrab == true) {
								this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = gravity;
						}
				}

				if (activateClimbEdge == true) {
						ClimbEdge ();
						edgeTimer ++;
						ableToMoveLeft = false;
						ableToMoveRight = false;
						if (edgeTimer == 20) {
								this.GetComponent<Rigidbody2D> ().isKinematic = false;
								edgeTimer = 0;
								activateClimbEdge = false;
								ableToClimb = false;
								ableToMoveLeft = true;
								ableToMoveRight = true;
						}

				}

				if (Input.GetKeyDown (KeyCode.Space)) {
						meleeAttack = true;
				}
				if (Input.GetMouseButton (1)) {
						rangedAttack = true;
						var zCam = -Camera.main.transform.position.z;
						var mPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, zCam));


						var bullet1 = Instantiate (bulletPrefab, this.transform.position, Quaternion.LookRotation (mPos - transform.position));
				}
				//save left click for mouse interactions.
		}

		void ClimbEdge ()
		{

				this.GetComponent<Rigidbody2D> ().isKinematic = true;
				if (climbWhat == "Right") {
						this.transform.position = Vector3.Lerp (this.transform.position, new Vector3 (this.transform.position.x + 0.6f, this.transform.position.y + 1.5f, this.transform.position.z), Time.deltaTime * 3);
				}
				if (climbWhat == "Left") {
						this.transform.position = Vector3.Lerp (this.transform.position, new Vector3 (this.transform.position.x - 0.6f, this.transform.position.y + 1.5f, this.transform.position.z), Time.deltaTime * 3);
				}
		}
	
		void OnCollisionEnter (Collision whatIHit)
		{
		
				Debug.Log ("HIT");
		
		
				if (whatIHit.gameObject.name == "Platform") {
						onGround = true;
				}

		}

		void LateUpdate ()
		{
				lastFrameYPos = this.transform.position.y;
		}
}
