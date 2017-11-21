using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(NpcMovement))]
public class StateEnemyBehavior : MonoBehaviour {
	
	public Transform[] wayPoints;
	[HideInInspector] public Vector3 posPlayer;
	[HideInInspector] public Transform target;
	[HideInInspector] public int moveSpeed = 4;

	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public ChaseState chaseState;

	public static StateEnemyBehavior Instance;

    private NpcMovement theController;

	void Awake(){
        theController = GetComponent<NpcMovement>();

		patrolState = new PatrolState (this, theController);
		chaseState = new ChaseState (this, theController);
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