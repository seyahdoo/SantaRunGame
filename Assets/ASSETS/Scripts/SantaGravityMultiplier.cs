using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaGravityMultiplier : MonoBehaviour {

	public float ClimbUpMultiplier = .5f;
	public float FallDownMultiplier = 3f;

	public float FallVelocityTreshold = .3f;

	public float gravityScale = 1.0f;

	public static float globalGravity = -9.81f;

	Rigidbody m_rb;

	void Awake ()
	{
		m_rb = GetComponent<Rigidbody>();
		m_rb.useGravity = false;
	}

	void FixedUpdate ()
	{
		if (m_rb.velocity.y < FallVelocityTreshold) {
			gravityScale = FallDownMultiplier;
		} else {
			gravityScale = ClimbUpMultiplier;
		}

		Vector3 gravity = globalGravity * gravityScale * Vector3.up;
		m_rb.AddForce(gravity, ForceMode.Acceleration);
	}
	


}
