using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
	public float offsetXRot = 0.0f;
	public float offsetYRot = 0.0f;
	public float offsetZRot = 0.0f;

	public void SetOffsets(float x, float y, float z) {
		offsetXRot = x;
		offsetYRot = y;
		offsetZRot = z;
	}

	void Update ()
	{
		transform.localRotation = transform.localRotation * Quaternion.Euler (offsetXRot, offsetYRot, offsetZRot);
	}
}
