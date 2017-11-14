using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateEnemyBehavior : MonoBehaviour {
	
	public Transform[] wayPoints;

	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public PatrolState patrolState;

	public static StateEnemyBehavior Instance;

	void Awake(){
		patrolState = new PatrolState (this);
	}

	void Start (){
		currentState = patrolState;
	}

	void Update (){
		currentState.UpdateState ();
	}
}