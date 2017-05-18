using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour {

    public bool playerInVehicle;
    public Animator anim;

	// Use this for initialization
	void Start () {
        anim.SetBool("IsMoving", false);
        playerInVehicle = false;
	}

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (playerInVehicle)
        {
            Rigidbody ship = GetComponent<Rigidbody>();
            float jmp = Input.GetAxis("Jump");
            Vector3 force = new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), jmp);
        }
    }

	// Update is called once per frame
	void Update () {
        if (playerInVehicle) {
            anim.SetBool("IsMoving", true);
        }
	}


}
