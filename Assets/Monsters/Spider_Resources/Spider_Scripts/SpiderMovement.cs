using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpiderMovement : MonoBehaviour {
    //
	private Animator anim;
    private UnityEngine.AI.NavMeshAgent nav;
    //
	public float startingHealth;
	public float currentHealth;
    public float attackRange;
    public float timeBetweenAttacks;
    public PlayerHealth playerHealth;
    //
    private float timer;
    private bool inSight;
	private bool inRange;
    private bool playerSeenRecently;
    private float distToTarget;
    //
	//
    //
	private bool isDead = false;
    //
	public int damage;
	private bool damaged = false;
    //
	// Use this for initialization
	void Awake () {
        distToTarget = Vector3.Distance(GetComponent<EnemyMove>().Target.position, transform.position);
        anim = GetComponent<Animator> ();
        anim.SetBool("Idle", true);
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
		currentHealth = startingHealth;
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        bool playerIsAlive = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().currentHealth > 0;
        timer += Time.deltaTime;
        //
        if (!isDead && playerIsAlive)
        {
            //
            inRange = GetComponent<EnemyMove>().inRange;
            inSight = GetComponent<EnemyMove>().inSight;
            playerSeenRecently = GetComponent<EnemyMove>().playerSeenRecently;
            distToTarget = Vector3.Distance(GetComponent<EnemyMove>().Target.position, transform.position);
            //
            //Spider knows player is nearby, will continue searching
            if (playerSeenRecently || inRange)
            {
                //Debug.Log("Setting IsWalking = true, playerSeenRecently = " + playerSeenRecently + ", inRange = " + inRange);
                anim.SetBool("IsWalking", true);
            }
            else
            {
                //Debug.Log ("Setting IsWalking = false, playerSeenRecently = " + playerSeenRecently + ", inRange = " + inRange);
                anim.SetBool("IsWalking", false);
                anim.SetBool("Idle", true);
            }
            //
            //timer += Time.deltaTime;
            //Debug.Log("timer = " + timer);
            //
            if (distToTarget <= attackRange && timer >= timeBetweenAttacks)
            {
                transform.LookAt(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position);
                anim.SetTrigger("IsAttacking");
                timer = 0f;
                playerHealth.TakeDamage(damage);                
                Debug.Log("Attacking Player " + distToTarget + ", timer = " + timer);
            }
            
        }
        else { anim.SetBool("IsWalking", false); }
        

	}

	//When spider is damaged call this method
	public void TakeDamage(int amount){
		Debug.Log ("Spider has been hit for " + amount + " damage");
		if (inRange && !isDead) {
			currentHealth -= amount;
		}

		if (currentHealth <= 0 && !isDead) {
			Death ();
		}

	}

	//If spider health is <= 0 call this method
	void Death(){
        System.Random rand = new System.Random();

        if (rand.Next(2) > 1) { anim.SetTrigger("Die"); }
        else { anim.SetTrigger("Die2"); }
		isDead = true;		        
		Debug.Log ("Spider has died!");
	}
}



