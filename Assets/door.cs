using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

	public bool locked = true;
	public string keyNeeded = "blueKey";
	public bool keyBreaker = false;
	public Vector3 openLocation;
	public float overTime = 1f;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = this.gameObject.transform.position;
		if (openLocation == new Vector3(0,0,0)) {
			Debug.Log ("this element doesnt contain the opened position");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D whatiHit){
		if (whatiHit.gameObject.tag == "Player") {
			if (whatiHit.gameObject.GetComponent<playerManager> ().inventory.Contains(keyNeeded)) {
				if (locked == true) {
					Debug.Log("this door is locked");
					locked = false;
					unlockDoor ();
				}
			} else {
				Debug.Log ("doesnt contain " + keyNeeded);
			}
		}
	}

	void unlockDoor(){
		StartCoroutine (moveToPosition());
		return; 
	}

	IEnumerator moveToPosition(){
		float startTime = Time.time;
		while(Time.time < startTime + overTime){
			transform.position = Vector3.Lerp(startPosition, openLocation, (Time.time - startTime)/overTime);
			yield return null;
		}
		transform.position = openLocation;
	}

}
