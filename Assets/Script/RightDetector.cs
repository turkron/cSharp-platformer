using UnityEngine;
using System.Collections;



public class RightDetector : MonoBehaviour
{

		//public float pushBackValue = 0.0f;
		private PlayerMovement parentClass;
		public bool canGrab = true;
		public bool canClimb = true;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{

				parentClass = this.transform.parent.gameObject.GetComponent<PlayerMovement> ();

		}

		void OnCollisionEnter2D (Collision2D enterHit)
		{

				if (enterHit.gameObject.tag == "Climb") {
						this.transform.parent.gameObject.transform.position = new Vector2 (this.transform.parent.gameObject.transform.position.x, enterHit.transform.position.y - 0.45f);
						parentClass.ableToMoveRight = false;
				}

		}

		void OnCollisionStay2D (Collision2D whatHit)
		{

				if (whatHit.gameObject.tag == "Respawn") {
						if (parentClass.respawnPoint != null) {
								parentClass.respawnPoint.gameObject.GetComponent<Renderer> ().material.color = Color.white;
								parentClass.respawnPoint.gameObject.GetComponent<BoxCollider2D> ().enabled = true;
						}

						parentClass.respawnPoint = whatHit.gameObject;
						whatHit.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
						whatHit.gameObject.GetComponent<Renderer> ().material.color = Color.black;
				}

				if (whatHit.gameObject.tag == "Platform") {
						parentClass.playerSpeed = 0;
						parentClass.ableToMoveRight = false;
				}
				if (whatHit.gameObject.tag == "GrabPoint" && canGrab) {
						parentClass.playerSpeed = 0;
						this.transform.parent.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
						this.transform.parent.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
						parentClass.ableToJump = true;
						parentClass.numOfJumps = parentClass.maxJumps;
						parentClass.ableToMoveRight = false;
						canGrab = false;
						parentClass.rightGrab = true;
				}

				if (whatHit.gameObject.tag == "Climb" && canClimb == false) {

						parentClass.playerSpeed = 0;
						this.transform.parent.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
						this.transform.parent.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
						parentClass.climbWhat = "Right";
						parentClass.ableToJump = false;
						parentClass.ableToClimb = true;
						parentClass.numOfJumps = parentClass.maxJumps;
						parentClass.ableToMoveRight = false;
						canClimb = true;
						parentClass.rightGrab = true;

				}
		}
		void OnCollisionExit2D (Collision2D exitHit)
		{
				parentClass.ableToMoveRight = true;
		
				if (exitHit.gameObject.tag == "GrabPoint") {
						this.transform.parent.gameObject.GetComponent<Rigidbody2D> ().gravityScale = parentClass.gravity;
						canGrab = true;
						parentClass.rightGrab = false;
				}

				if (exitHit.gameObject.tag == "Climb") {
						this.transform.parent.gameObject.GetComponent<Rigidbody2D> ().gravityScale = parentClass.gravity;
						canClimb = false;
						parentClass.ableToClimb = false;
						parentClass.rightGrab = false;
				}

		}
}
