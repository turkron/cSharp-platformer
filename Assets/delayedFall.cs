using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayedFall : MonoBehaviour {

	public float overTime = 1f;
	public bool struck = false;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay2D(Collision2D whatHit){
		Debug.Log ("Something touched me!");
		Debug.Log (whatHit.gameObject.tag);
		if (whatHit.gameObject.tag == "Player" && !struck) {
			struck = !struck;
			StartCoroutine (startCollasping());
		}
	}

	IEnumerator startCollasping(){
		float startTime = Time.time;
		while(Time.time < startTime + overTime){
			yield return null;
		}
		this.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		this.GetComponent<Rigidbody2D> ().gravityScale = 1;
		if (this.GetComponent<resetAfterDelay> () != null) {StartCoroutine (this.GetComponent<resetAfterDelay> ().startRespawning ());}
		struck = !struck;
	}


}
