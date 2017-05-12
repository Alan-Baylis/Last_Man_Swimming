using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByDistance : MonoBehaviour
{
	// destroy when this far from starting point
	public float maxDistance;
	private Vector3 startPosition;

	void Start ()
	{
		startPosition = transform.position;
	}

	void Update ()
	{
		if (Vector3.Distance (startPosition, transform.position) > maxDistance) {
			Destroy (gameObject);
		}
	}
}
