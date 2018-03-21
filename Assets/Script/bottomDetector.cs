using UnityEngine;
using System.Collections;

public class bottomDetector : MonoBehaviour {

	private PlayerMovement parentClass;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		parentClass = this.transform.parent.gameObject.GetComponent<PlayerMovement>();
	}

	void OnCollisionStay2D(Collision2D whatHit){
		if (whatHit.gameObject.tag == "Platform") {
			if (parentClass.JumpStatus != "Jumping") {
				parentClass.numOfJumps = parentClass.maxJumps;
				parentClass.ableToJump = true;
			}
		}
//		if (whatHit.gameObject.tag == "GrabPoint") {
//			parentClass.numOfJumps = parentClass.maxJumps;
//			parentClass.ableToJump = true;
//		}

//		if(whatHit.gameObject.tag == "Respawn"){
//			if(parentClass.respawnPoint != null){
//				parentClass.respawnPoint.gameObject.GetComponent<Renderer>().material.color = Color.white;
//				parentClass.respawnPoint.gameObject.GetComponent<BoxCollider2D>().enabled = true;
//			}
//			
//			parentClass.respawnPoint = whatHit.gameObject;
//			whatHit.gameObject.GetComponent<BoxCollider2D>().enabled = false;
//			whatHit.gameObject.GetComponent<Renderer>().material.color = Color.black;
//		}

		if (whatHit.gameObject.tag == "Death") {
			parentClass.transform.position = parentClass.respawnPoint.transform.position;
		}

	}

}
