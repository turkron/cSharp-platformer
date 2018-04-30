using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySight : MonoBehaviour {

	public float fieldOfViewAngle = 110f;
	public bool playerInSight;
	public Vector2 personalLastSighting;
	public float range = 10;

	private GameObject player;
	private Vector2 previousSighting; //last frame positioning. 


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider2D other){
		if (other.gameObject == player) {
			Vector2 direction = other.transform.position - transform.position;

			float angle = Vector2.Angle (direction, transform.forward);

			if (angle < fieldOfViewAngle * 0.5f) {
				RaycastHit hit;
				if (Physics2D.Raycast (transform.position, direction.normalized, out hit, range)) {
					if (hit.collider.gameObject == player) {
						//player in sight and in range. activate a script to handle this. 
					}
				}


			}
		}
	}
}
