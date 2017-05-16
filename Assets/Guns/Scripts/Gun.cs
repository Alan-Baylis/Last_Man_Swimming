using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	// fire rate in shots per second
	public float fireRate;
	// speed of bullet
	public float shotSpeed;
	// how far bullet travels before destruction
	public float range;
	// how much damage shots do on contact with an enemy
	public int damage;
	public GameObject shot;
	private Rigidbody player;
	private Transform shotOrigin;
    public ParticleSystem flash;
    private AudioSource gunFire;
	private float nextFire;

	void Start ()
	{
        //flash = GetComponentInChildren<ParticleSystem>();
        gunFire = GetComponentInChildren<AudioSource>();
		nextFire = Time.time;
		Transform[] ts = gameObject.GetComponentsInChildren<Transform> ();
		foreach (Transform t in ts) {
			if (t != null && t.gameObject != null && t.gameObject.CompareTag ("ShotOrigin")) {
				shotOrigin = t;
			}
		}
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody> ();
	}

	void Update ()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + 1.0f / fireRate;
			//Debug.Log (shotOrigin);
			GameObject newShot = Instantiate (shot, shotOrigin.position, shotOrigin.rotation) as GameObject;
			newShot.GetComponent<Rigidbody> ().velocity = shotSpeed * shotOrigin.up + Vector3.Project (player.velocity, shotOrigin.up);
			newShot.AddComponent<DestroyByDistance> ().maxDistance = range;
			newShot.AddComponent<DestroyByContact> ().damage = damage;
            flash.Play();
            gunFire.Play();
		}

        
	}
}