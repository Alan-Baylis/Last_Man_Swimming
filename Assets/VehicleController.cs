using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VehicleController : MonoBehaviour {

    public GameObject player;
    public Canvas invantory;
    public Object playerBackup;
    public ParticleSystem left;
    public ParticleSystem right;
    public Camera firstPerson;
    public Camera thirdPerson;
    public Text message;
    public Animator anim;
    public float thrust;
    public float rotSpeed;

    private Rigidbody shipRB;
    private Camera shipCam;
    public bool playerInVehicle;
    private bool camInPositionA;

	// Use this for initialization
	void Start () {
        firstPerson.enabled = false;
        thirdPerson.enabled = false;
        shipCam = GetComponentInChildren<Camera>();
        shipRB = GetComponent<Rigidbody>();
        shipCam.enabled = false;
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
            float vert = Input.GetAxis("Vertical");
            float horiz = Input.GetAxis("Horizontal");
            Vector3 force = (shipRB.transform.right) + (shipRB.transform.forward * -vert * thrust) + (shipRB.transform.up*jmp*thrust);
            shipRB.AddForce(force);
            Vector3 incrementalRotation = new Vector3(0,horiz,0);
            transform.eulerAngles = transform.eulerAngles + incrementalRotation*rotSpeed;
            Debug.Log("Adding Force");
        }
    }

	// Update is called once per frame
	void Update () {
        if (playerInVehicle) {
            message.text = "Press G to exit vehicle, press C to change perspective";
            if (Input.GetKeyDown(KeyCode.G)) {
                Debug.Log("Exiting Ship");
                ExitVehicle();
            }            

        } else if (Vector3.Distance(transform.position, player.transform.position) < 10 && !playerInVehicle) {
            Debug.Log("Player Can See Ship!");
            message.text = "Press G to enter vehicle";
            if (Input.GetKeyDown(KeyCode.G) && !playerInVehicle)
            {
                Debug.Log("Entering Ship");
                EnterVehicle();
            }            
        }

        if (Input.GetKeyDown(KeyCode.C) && playerInVehicle) {
            if (camInPositionA) {
                firstPerson.enabled = false;
                thirdPerson.enabled = true;
                camInPositionA = false;
            }
            else {
                firstPerson.enabled = false;
                thirdPerson.enabled = true;
                camInPositionA = true;
            }
            
        }
	}

    private void EnterVehicle() {
        left.Play();
        right.Play();
        invantory.enabled = false;
        player.GetComponentInChildren<Camera>().enabled = false;
        Destroy(player, 0.5f);
        shipCam.enabled = true;
        playerInVehicle = true;
        Debug.Log("Player should be in ship");
    }

    private void ExitVehicle() {
        left.Pause();
        right.Pause();
        Instantiate(playerBackup);
        player.GetComponentInChildren<Camera>().enabled = true;
        shipCam.enabled = false;
        playerInVehicle = false;
        Debug.Log("Player should be out of ship");
    }


}
