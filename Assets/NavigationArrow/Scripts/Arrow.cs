using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {


	public float rotationSpeed;
	public AnimationCurve heightCurve;


	float initialHeight;

	void Awake(){
		initialHeight = transform.position.y;
	}

	// Update is called once per frame
	void Update () {

		transform.Rotate (new Vector3 (0, rotationSpeed * Time.deltaTime, 0));

		Vector3 p = transform.position;
		p.y = initialHeight + heightCurve.Evaluate (Time.time);
		transform.position = p;

	}


}
