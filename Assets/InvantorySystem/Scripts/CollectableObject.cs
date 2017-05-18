/*
Copyright 2016 Frederic Babord

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

*/
using System.Collections;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
	public int quantity = 0;
	public InvantoryObject objectRefrence;
	private bool justSpawned = false;
	private GameObject player;
	private Light highlight;
	// the distance at which light intensity is maximized
	private float lightScaling = 45f;
	private float minLightIntensity = 0.05f;
	private float maxLightIntensity = 0.8f;
	public float justSpawnedTime = 1.5f;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		gameObject.AddComponent<Rigidbody> ();
		highlight = gameObject.GetComponent<Light> ();
		highlight.color = new Color (1f, 1f, 0.4f, 1f);
		highlight.range = 2;

		justSpawned = true;
		StartCoroutine (SpawnSleepTimer ());
	}

	void Update ()
	{
		if (!justSpawned) {
			// set light intensity based on distance
			float distance = Vector3.Distance (transform.position, player.transform.position);
			highlight.intensity = Mathf.Clamp (distance / lightScaling, minLightIntensity, maxLightIntensity);
		} else {
			highlight.intensity = 0.0f;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player" && !justSpawned) {
			other.GetComponent<Invantory> ().AddItemToInvanntory (this);
			Destroy (gameObject);
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player") {
			justSpawned = false;
			StopCoroutine (SpawnSleepTimer ());
		}
	}

	IEnumerator SpawnSleepTimer ()
	{
		yield return new WaitForSeconds (justSpawnedTime);
		justSpawned = false;
	}
}