using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetAfterDelay : MonoBehaviour {

	public float overTime = 3f;
	private Vector3 startPos;
	private Quaternion startRot;
	// Use this for initialization
	void Start () {
		startPos = this.transform.position;
		startRot = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public IEnumerator startRespawning(){
		float startTime = Time.time;
		while(Time.time < startTime + overTime){
			//find out how to alpha outover time.
			yield return null;
		}
		this.transform.position = startPos;
		this.transform.rotation = startRot;
		this.GetComponent<Rigidbody2D> ().gravityScale = 0;
		this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		this.GetComponent<Rigidbody2D> ().angularVelocity = 0;
		this.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Kinematic;
	}
}
