using UnityEngine;
using System.Collections;

public class platformMovement : MonoBehaviour {

	private bool move = false;
	public float moveby = 0.001f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (move == false) {
			this.transform.Translate (Vector2.up * moveby);
					move = true;
				} else {
			this.transform.Translate (Vector2.up * (moveby - moveby * 2));
					move = false;
				}

	}
}
