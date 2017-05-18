using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour {

    public GameObject torpedo;
    public float shotSpeed;
    public float range;
    public int damage;

    private GameObject player;
    
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            
             
            fireTorpedo(torpedo);
        }
	}

    private void fireTorpedo(GameObject torpedo) {
        //Instantiate(torpedo, transform);
        torpedo.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        torpedo.transform.eulerAngles = new Vector3(0, 0, 90);
        torpedo.transform.position = new Vector3(0.0005f, 0.0106f, 0.0157f);
        GameObject newShot = Instantiate(torpedo, transform) as GameObject;
        newShot.AddComponent<Rigidbody>().GetComponent<Rigidbody>().velocity = shotSpeed * transform.forward + Vector3.Project(GetComponentInParent<Rigidbody>().velocity, transform.up);
        newShot.AddComponent<DestroyByDistance>().maxDistance = range;
        newShot.AddComponent<DestroyByContact>().damage = damage;
    }
}
