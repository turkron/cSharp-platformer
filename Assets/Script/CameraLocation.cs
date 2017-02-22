using UnityEngine;
using System.Collections;

public class CameraLocation : MonoBehaviour {

	public GameObject Player;

	// Use this for initialization
	void Start () {

		Player = GameObject.Find ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.position = new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y, this.transform.position.z);
//		this.transform.position = new Vector3(Mathf.Lerp (this.transform.position.x, Player.transform.position.x, Time.deltaTime * 3),
//		                                      Mathf.Lerp (this.transform.position.y, Player.transform.position.y, Time.deltaTime * 3), 
//		                                      this.transform.position.z);

	}
}
