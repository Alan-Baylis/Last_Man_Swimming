using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
	public float offsetXRot = 0.0f;
	public float offsetYRot = 0.0f;
	public float offsetZRot = 0.0f;
	private Quaternion parentRotation;

	void Update ()
	{
		parentRotation = transform.parent.gameObject.transform.rotation;
		transform.rotation = parentRotation * Quaternion.AngleAxis (offsetXRot, Vector3.forward)
		* Quaternion.AngleAxis (offsetYRot, Vector3.up)
		* Quaternion.AngleAxis (offsetZRot, Vector3.right);
	}
}
