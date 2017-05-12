using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController : MonoBehaviour
{
	private Rigidbody rb;
	public float moveSpeed;
	public float swimUpSpeed;
	public float swimDownSpeed;
	public static float waterLevel = 100;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}


	void FixedUpdate ()
	{
		float moveRight = Input.GetAxis ("Horizontal");
		float moveUp = Input.GetAxis ("Jump");
		float moveDown = Input.GetAxis ("Fire3");
		float moveForward = Input.GetAxis ("Vertical");

		Vector3 movement = moveSpeed * moveRight * rb.transform.right + (moveUp * swimUpSpeed - moveDown * swimDownSpeed) * rb.transform.up + moveSpeed * moveForward * rb.transform.forward;
		rb.AddForce (movement);
	}

	void Update ()
	{
		// prevent going above the water level
		transform.position = new Vector3 (transform.position.x, Mathf.Min (transform.position.y, waterLevel), transform.position.z);
	}
}
