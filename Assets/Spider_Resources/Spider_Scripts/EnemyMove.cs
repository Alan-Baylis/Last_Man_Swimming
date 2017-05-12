using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	private Transform Target;
    public float distToTarget;
	private UnityEngine.AI.NavMeshAgent nav;

	// The range the spider can see once the spider notices the player
	public float range;
    public bool inRange;

    // How far the spider can see when it does not know the player is there
    public float sightRange;
    public bool inSight;
    
    //Player's health is > 0
	private bool playerIsAlive;    

	// If the player has been seen 
	public bool playerSeenRecently = false;

	// How long before the enemy forgets the player
	public float memoryDuration;
	private float timeElapsed = 0;

	//Random movement settings
	private Vector3 startingPoint;
	private Vector3 rndShift;
	public float roamRange;
	public float moveSpeed;
	public float rotationSpeed;

	// Use this for initialization
	void Awake () {
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		Target = GameObject.FindGameObjectWithTag("Player").transform;
		startingPoint = transform.position;        
	}

	// Update is called once per frame
	void Update () {
		
		playerIsAlive = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ().currentHealth > 0f;

		bool spiderAlive = GetComponent<SpiderMovement>().currentHealth > 0f;
        Debug.Log("spiderAlive = " + spiderAlive);

        if (spiderAlive && playerIsAlive) {

            //Calculate the distance from enemy to player
            distToTarget = Vector3.Distance(Target.position, transform.position);
            //
            inRange = distToTarget < range;
            inSight = distToTarget < sightRange;
            //
            //If the enemy has seen the player recently or can see the player, enable movement
            if (inRange || playerSeenRecently)
            {
                //
                //
                if (inRange)
                {
                    //System.Console.WriteLine("Chasing");
                    //Move the enemy towards the target
                    nav.enabled = true;
                    nav.SetDestination(Target.position);
                    playerSeenRecently = true;
                    //Debug.Log("Chasing Player");
                    //
                }
                else if (playerSeenRecently)
                {
                    //Don't use the NavMesh to move enemy
                    //nav.enabled = false;
                    //
                    //Track how long since player was seen
                    playerSeenRecently = rememberPlayer(timeElapsed, memoryDuration);
                    //Debug.Log("Running Random Movement");
                    //
                    if (Vector3.Distance(transform.position, rndShift) > 0.05f)
                    {
                        // move toward target
                        transform.position = Vector3.MoveTowards(transform.position, rndShift, Time.deltaTime * moveSpeed);
                        Quaternion targRot = Quaternion.LookRotation(rndShift - transform.position);
                        transform.rotation = Quaternion.Slerp(transform.rotation, targRot, Time.deltaTime * rotationSpeed);
                    }
                    else
                    {
                        // almost arrived at target, get a new one
                        randomizeTarget();
                    }
                }

            }else {
                nav.enabled = false;
            }

        } else {
            nav.enabled = false;
        }


	}



	/*
	 * find a random position in the map to move to
	 */
	private void randomizeTarget() {
		rndShift = startingPoint + roamRange * Random.insideUnitSphere;
		rndShift.y = startingPoint.y;
	}

	/*
	 * If the player has been seen within the timeLimit the the enemy remembers the player and will 
	 * continue to search for him.
	 */
	private bool rememberPlayer(float timeElapsed, float timeLimit){
		//Increment time since player was last in range
		timeElapsed += Time.deltaTime;

		//If time limit has been exceeded 
		bool timeExceeded = timeElapsed > timeLimit;

		if (timeExceeded) {
			//Enemy should forget target 
			timeElapsed = 0f;
			return false;
		} else {
			//Enemy should continue to search for the target
			return true;
		}

	}
}
