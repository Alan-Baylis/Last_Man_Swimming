using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

	public int damage;

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
			return;
		if (other.gameObject.CompareTag ("Spider")) {
			other.GetComponent<SpiderMovement> ().TakeDamage (damage);
		}
		Destroy (gameObject);
	}
}
