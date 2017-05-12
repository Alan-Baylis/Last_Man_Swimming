using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour {
    private ParticleSystem flash;
	// Use this for initialization
	void Start () {
        flash = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Flash is running");
            flash.Emit(100);
        }	
	}
}
