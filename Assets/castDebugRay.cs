using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castDebugRay : MonoBehaviour {

	public float castDistance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		LineRenderer lineRenderer = this.GetComponent<LineRenderer>();
		lineRenderer.SetVertexCount(2);
		lineRenderer.SetPosition(0, transform.position);
		lineRenderer.SetPosition(1, transform.forward * castDistance + transform.position);
	}
}
