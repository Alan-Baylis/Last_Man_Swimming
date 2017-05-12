using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour {

	public GameObject Player;
	public float xOffset;
	public float yOffset;
	public float zOffset;
	private Vector3 offset;

	private float rotX = 0f;
	private float rotY = 0f;
	public float mouseSensitivity = 100f;
	public float clampAngle = 80.0f;

	// Use this for initialization
	void Start () {
		Vector3 offset = Player.transform.position - new Vector3(xOffset, yOffset, zOffset);
		transform.position = offset;

		/*
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;	
		*/
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Player.transform.position - new Vector3(xOffset, yOffset, zOffset);
		/*
		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");

		rotY += mouseX * mouseSensitivity * Time.deltaTime;
		rotX += mouseY * mouseSensitivity * Time.deltaTime;

		rotX = Mathf.Clamp (rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler (rotX, rotY, 0.0f);

		transform.rotation = localRotation;
		*/
	}
}
