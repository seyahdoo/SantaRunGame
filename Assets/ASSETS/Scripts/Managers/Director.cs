using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : seyahdoo.other.Singleton<Director> {


	void Start(){
	
		//Time.timeScale = 5f;
	
	}


	public void OnPresentDelivered(){
	
	
	}

	public float timeScale = 1f;

	void Update(){
		Time.timeScale = timeScale;
	
	}




}
