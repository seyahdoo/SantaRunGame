using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneyCollider : MonoBehaviour {

	public GameObject giftBox1;
	public GameObject giftBox2;
	public GameObject giftBox3;
	public GameObject giftBox4;
	public GameObject giftBox5;

	public float initialAngle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag != "Player")
			return;
		
		GameObject gift;
		switch((int) Mathf.Floor(Random.Range(0,5))) {
		case 0:
			gift = Instantiate (giftBox1);
			break;
		case 1:
			gift = Instantiate (giftBox2);
			break;
		case 2:
			gift = Instantiate (giftBox3);
			break;
		case 3:
			gift = Instantiate (giftBox4);
			break;
		default:
			gift = Instantiate (giftBox5);
			break;
		}
		Vector3 pos = other.gameObject.transform.position;
		pos.y -= 1;
		gift.transform.position = pos;

		/*
		Rigidbody giftBody = gift.GetComponent<Rigidbody> ();

		Vector3 p = this.gameObject.transform.position;

		float gravity = Physics.gravity.magnitude;
		// Selected angle in radians
		float angle = initialAngle * Mathf.Deg2Rad;

		// Positions of this object and the target on the same plane
		Vector3 planarTarget = new Vector3(p.x, 0, p.z);
		Vector3 planarPostion = new Vector3(giftBody.position.x, 0, giftBody.position.z);

		// Planar distance between objects
		float distance = Vector3.Distance(planarTarget, planarPostion);
		// Distance along the y axis between objects
		float yOffset = giftBody.position.y - p.y;

		float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));

		Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

		// Rotate our velocity to match the direction between the two objects
		float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPostion) * (p.x > giftBody.position.x ? 1 : -1);
		Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;

		// Fire!
		giftBody.velocity = finalVelocity;
		*/

		Present p = gift.GetComponent<Present> ();
		p.ThrowTo (pos, transform.position);

		// Alternative way:
		// rigid.AddForce(finalVelocity * rigid.mass, ForceMode.Impulse);
		this.gameObject.SetActive(false);
	}
}
