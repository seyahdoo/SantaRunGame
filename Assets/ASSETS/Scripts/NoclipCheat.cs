using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoclipCheat : MonoBehaviour
{
	public bool Working = false;

	[Range(0, 5)]
	public float Sensivity = 2f;
	[Range(0, 2)]
	public float MoveSpeed = .2f;
	[Range(0, 2)]
	public float ShiftSpeedBoost = 1f;

	private float _moveSpeed = .2f;
	private float _ySpeed = 0;

	UnityStandardAssets.Characters.FirstPerson.FirstPersonController RealController;

	Rigidbody rb;

	void Awake(){
		RealController = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ();
		rb = GetComponent<Rigidbody> ();
	}

	void Update()
	{
		//LClick to lock cursor
		if (Input.GetKeyDown(KeyCode.N))
		{
			Cursor.lockState = CursorLockMode.Locked;
			Working = true;
			RealController.enabled = false;
			rb.isKinematic = true;
		}

		//If im now workin, there's nothing to do
		if (!Working) return;

		//ESC to unlock cursor 
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.B))
		{
			Cursor.lockState = CursorLockMode.None;
			Working = false;
			RealController.enabled = true;
			rb.isKinematic = false;

		}

		//LSHIFT to boost
		if (Input.GetKey(KeyCode.LeftShift))
			_moveSpeed = ShiftSpeedBoost;
		else
			_moveSpeed = MoveSpeed;

		//Handle QE
		if (Input.GetKey(KeyCode.Q)) _ySpeed = Mathf.Lerp(_ySpeed, -1, .05f);
		else if (Input.GetKey(KeyCode.E)) _ySpeed = Mathf.Lerp(_ySpeed, 1, .05f);
		else _ySpeed = Mathf.Lerp(_ySpeed, 0, .1f);

		//turn camera
		transform.localEulerAngles +=
			new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0)
			* Sensivity;

		//move camera
		transform.Translate(
			new Vector3(Input.GetAxis("Horizontal"),_ySpeed, Input.GetAxis("Vertical"))
			* _moveSpeed);

	}

}
