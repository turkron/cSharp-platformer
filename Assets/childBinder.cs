using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childBinder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			other.transform.parent = gameObject.transform;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			other.transform.parent = null;
		}
	}
}
