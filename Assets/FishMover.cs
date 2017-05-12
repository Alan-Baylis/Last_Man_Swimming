using UnityEngine;
using System.Collections;

public class FishMover : MonoBehaviour
{
	private Vector3 startingPoint;
	private Vector3 rndShift;
	public float roamRange;
	public float moveSpeed;
	public float rotationSpeed;

	//public Transform player;
	//public float fleeDistance;

	void Start ()
	{
		startingPoint = transform.position;
		randomizeTarget ();
	}

	void Update ()
	{
		//if (Vector3.Distance(transform.position, player.position) < fleeDistance) {
		//	// run from the player
		//	Debug.Log("OH GOD ITS THE PLAYER RUN");
		//	transform.position = Vector3.MoveTowards (transform.position, player.position - transform.position, Time.deltaTime * moveSpeed);
		//	transform.rotation = Quaternion.LookRotation (transform.position - player.position);
		//	transform.position = new Vector3 (transform.position.x, startingPoint.y, transform.position.z);
		//}
		if (Vector3.Distance (transform.position, rndShift) > 0.05f) {
			// move toward target
			transform.position = Vector3.MoveTowards (transform.position, rndShift, Time.deltaTime * moveSpeed);
			Quaternion targRot = Quaternion.LookRotation (rndShift - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, targRot, Time.deltaTime * rotationSpeed);
		} else {
			// almost arrived at target, get a new one
			randomizeTarget ();
		}
	}

	private void randomizeTarget() {
		rndShift = startingPoint + roamRange * Random.insideUnitSphere;
		rndShift.y = startingPoint.y;
	}

	void OnCollisionEnter (Collision collision)
	{
		Debug.Log ("FishMover collision");
		foreach (ContactPoint contact in collision.contacts) {
			rndShift = roamRange * contact.normal;
			rndShift.y = startingPoint.y;        
		}
	}

}
