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
}