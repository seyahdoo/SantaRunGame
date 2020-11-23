using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour {

	public float speedinv = 4f;
	public float maxHeight = 4f;

	//this will go 0,1
	public AnimationCurve heightCurve;


	//This deals with thowing
	public void ThrowTo(Vector3 from, Vector3 to){
		StartCoroutine (throwTo (from, to));
		//Debug.Log ("Thrown!");
	}


	IEnumerator throwTo(Vector3 f, Vector3 t){
		
		float startTime = Time.time;
		float yModifier = 0f;
		//float curHeight = 0f;

		yModifier = t.y;
		Vector3 posnew;

		while (true) {
		
			//Calculate x,z from time and from to
			posnew.x = Mathf.Lerp(f.x,t.x,(Time.time-startTime)/speedinv);
			posnew.z = Mathf.Lerp(f.z,t.z,(Time.time-startTime)/speedinv);

			//Calculate y from height curve and time
			posnew.y = yModifier + heightCurve.Evaluate((Time.time-startTime)/speedinv);

			transform.position = posnew;
		
			yield return new WaitForEndOfFrame ();
		}

	
	}







}
