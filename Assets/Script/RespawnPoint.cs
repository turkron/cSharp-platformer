using UnityEngine;
using System.Collections;

public class RespawnPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D whatHit)
	{

		if (whatHit.gameObject.tag == "Player") {
			playerManager parentClass = whatHit.gameObject.GetComponent<playerManager> ();

			if (parentClass.respawnPoint.gameObject != null) {
				if (parentClass.respawnPoint.gameObject.GetComponent<Renderer> ()) {
					parentClass.respawnPoint.gameObject.GetComponent<Renderer> ().material.color = Color.white;
					parentClass.respawnPoint.gameObject.GetComponent<BoxCollider2D> ().enabled = true;
				}
			}
				
			parentClass.respawnPoint = whatHit.gameObject;
			this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			this.gameObject.GetComponent<Renderer> ().material.color = Color.black;
		}

	}
}
