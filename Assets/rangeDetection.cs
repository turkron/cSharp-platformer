using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeDetection : MonoBehaviour {

	public string targetTag;
	public float scanDelayTime = 10f;
	public float scanDuration = 10f;
	public float maxRange = 10f;
	private float currentScanRange = 0f;
	private float scanIncrement; 

	// Use this for initialization
	void Start () {
		scanIncrement = maxRange / scanDuration;
		Debug.Log(scanIncrement);
		StartCoroutine (startUpDelay ());
	}
	
	// Update is called once per frame
	void Update () {}

	// we are going loop over a delayed coRoutine for a delayer timer, then activate a second on to scan over time calling scanForTarget on each call; cancelling if we find the player.
	IEnumerator startUpDelay(){
		float startTime = Time.time;
		while(Time.time < startTime + scanDelayTime){
			//whist it still counting, do nothing. 
			yield return null;
		}
		//done counting.
		StartCoroutine (scanOverTime());


	}

	IEnumerator scanOverTime(){
		Debug.Log ("scan Started");
		float startTime = Time.time;
		while(Time.time < startTime + scanDuration ||  scanForTarget (currentScanRange) == false){
			currentScanRange += scanIncrement;
			yield return scanForTarget (currentScanRange);
		}
		Debug.Log ("passed the conditions because : "+ (Time.time < startTime + scanDuration)+ (!scanForTarget (currentScanRange)));
		currentScanRange = 0;
	}


	bool scanForTarget(float scanRange){
		
		bool toReturn = false;
		var hitColliders = Physics2D.OverlapCircleAll (this.gameObject.transform.position, scanRange);
		foreach (Collider2D obj in hitColliders) {
			if (obj.GetType() == typeof(BoxCollider2D)) {
				if (obj.gameObject.tag == "Player") {
					Debug.Log ("FOUND TARGET");
					toReturn = true;
				}
			}
		}
		Debug.Log (toReturn);
		return toReturn;
	}


}
