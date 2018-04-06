using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay2D (Collision2D whatiHit){
		if (whatiHit.gameObject.tag == "Player") {
			Debug.Log ("player is in range");
		}
	}
}
