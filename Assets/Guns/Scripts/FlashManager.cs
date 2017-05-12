using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashManager : MonoBehaviour {
    private ParticleSystem flash;

	// Use this for initialization
	void Start () {
        flash = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !flash.isEmitting) {
            flash.Play();
        }
	}
}
