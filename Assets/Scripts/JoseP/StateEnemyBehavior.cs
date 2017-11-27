using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateEnemyBehavior : MonoBehaviour {
	
	public Transform[] wayPoints;
	[HideInInspector] public Vector3 posPlayer;
	[HideInInspector] public Transform target;
	[HideInInspector] public int moveSpeed = 4;

	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public ChaseState chaseState;

	public static StateEnemyBehavior Instance;

	void Awake(){
		patrolState = new PatrolState (this);
		chaseState = new ChaseState (this);
	}

	void Start (){
		currentState = patrolState;
	}

	void Update (){
		currentState.UpdateState ();
		posPlayer = this.transform.position;
	}

	public void SightTriggered(Collider2D other) {
		if (other.tag == "Player") {
			target = other.transform;
			currentState.ToChaseState();
		}
	}

	public void SightExit(Collider2D other) {
		if (other.tag == "Player") {;
			currentState.ToPatrolState();
		}
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "vomit")
		{
			Debug.Log("TRIGGERED");
			/*enemy.moveSpeed = 0;
            stopping = true;
            time = 0.0f;*/
			moveSpeed = 0;
			//new WaitForSecondsVomit();
			//moveSpeed = 4;
			//StartCoroutine(TimeLapse());
			/* Vector3 velocity;
                if (!this.rigidbody2D.isSleeping){
                    this.rigidbody.sleep();
                    this.velocity = this.rigidbody.velocity;
                } else {
                    this.rigidbody.WakeUp();
                    this.rigidbody.velocity = this.velocity;
                }*/
		}
	}
}