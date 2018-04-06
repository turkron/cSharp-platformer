using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour {

	public string state = "initial";
	public bool upDirection = true;
	public float distanceToTravel = 10.0f;
	public float currentTimer = 0f;
	public int travelTimer = 1;
	public int stationaryTimer = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// idea is to use a state machine to control the timing, direction and movement of the lift. 

		if (state == "initial") {
			currentTimer = travelTimer;
			state = "move";
			checkDirection ();
		}

		if (state == "stationary") {
			currentTimer -= Time.deltaTime;
			if (currentTimer < 0) {
				state = "move";
				checkDirection ();
			}
		}
		
	}

	void checkDirection(){
		if (upDirection) {
			MoveObjectUp (travelTimer);
		} else {
			MoveObjectDown (travelTimer);
		}

		return;
	}

	void MoveObjectUp(float overTime){
		Vector3 currentPos = this.transform.position;
		Vector3 targetPos = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + distanceToTravel, this.gameObject.transform.position.z);
		StartCoroutine(MoveObject (currentPos, targetPos, overTime));
		return;
	}

	void MoveObjectDown(float overTime){
		Vector3 currentPos = this.transform.position;
		Vector3 targetPos = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - distanceToTravel, this.gameObject.transform.position.z);
		StartCoroutine(MoveObject (currentPos, targetPos, overTime));
		return;
	}

	IEnumerator MoveObject(Vector3 source, Vector3 target, float overTime)
	{
		float startTime = Time.time;
		while(Time.time < startTime + overTime)
		{
			transform.position = Vector3.Lerp(source, target, (Time.time - startTime)/overTime);
			yield return null;
		}
		upDirection = !upDirection;
		transform.position = target;
		state = "stationary";
		currentTimer = stationaryTimer;
	}
}
