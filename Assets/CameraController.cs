using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject Player;
	public float verticalOffset;
	public float horizontalOffset;

	// Use this for initialization
	void Start () {		
		transform.position = new Vector3(0, 0, 0);	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(0, 0, 0);	
	}
}
