using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contactKill : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay2D(Collision2D whatHit){
		Debug.Log ("Something touched me!");
		Debug.Log (whatHit.gameObject.tag);
		if (whatHit.gameObject.tag == "Player") {
			Debug.Log (whatHit.gameObject.GetComponent<playerManager> ().respawnPoint.transform.position);
			whatHit.transform.position = whatHit.gameObject.GetComponent<playerManager>().respawnPoint.transform.position;
		}
	}
}
