using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulseRangeDetection : MonoBehaviour {

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
		while(Time.time < startTime + scanDuration){
			if(scanForTarget (currentScanRange) == null){
				currentScanRange += scanIncrement;
				yield return null;
			} else {
				break;
			}
		}
		currentScanRange = 0;
	}


	GameObject scanForTarget(float scanRange){
		
		GameObject toReturn = null;
		var hitColliders = Physics2D.OverlapCircleAll (this.gameObject.transform.position, scanRange);
		foreach (Collider2D obj in hitColliders) {
			if (obj.GetType() == typeof(BoxCollider2D)) {
				if (obj.gameObject.tag == "Player") {
					Debug.Log ("FOUND TARGET");
					toReturn = obj.gameObject;
				}
			}
		}
		Debug.Log (toReturn);
		return toReturn;
	}


}
