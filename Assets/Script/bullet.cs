using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {


	public int lifeSpan = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(new Vector3(0,0, 0.5f));
		lifeSpan--;
		if (lifeSpan < 98) {
			this.gameObject.GetComponentInChildren<BoxCollider2D> ().enabled = true;
		}

		if (lifeSpan < 1) {
			GameObject.Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D whatiHit){
		Debug.Log ("Ive shot something");
		if (whatiHit.gameObject.tag != "Player" && whatiHit.gameObject.tag != "Bullet") {
			Destroy (this.gameObject);
		}
				
		}
}
