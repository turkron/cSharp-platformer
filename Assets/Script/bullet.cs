using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(new Vector3(0,0, 0.5f));
	}

	void OnCollisionEnter2D (Collision2D whatiHit){
				GameObject.Destroy (this.gameObject);
		}
}
