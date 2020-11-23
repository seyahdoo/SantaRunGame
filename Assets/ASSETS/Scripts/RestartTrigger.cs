using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTrigger : MonoBehaviour {


	public Transform restartTransform;

	void OnTriggerEnter(Collider other) {
	
		//other.transform.position = restartTransform.position;
		//other.transform.rotation = restartTransform.rotation;

		SceneManager.LoadScene ("Level2");
	
	}
}
