using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

	public GameObject player;

	void OnCollisionEnter2D(Collision2D whatHit){
		if (whatHit.gameObject.tag == "Player") {
			player = whatHit.gameObject;
			Destroy (this.gameObject);
			payLoadFunction ();
		}

	}

	protected virtual void payLoadFunction(){

	}
}
