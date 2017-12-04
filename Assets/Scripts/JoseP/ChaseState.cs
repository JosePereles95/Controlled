using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState {

	StateEnemyBehavior enemy;
	private NpcMovement theController;

	public int rotationSpeed = 0;

	public ChaseState (StateEnemyBehavior enemy, NpcMovement controller) {
		this.enemy = enemy;
        theController = controller;
		enemy.moveSpeed = 5;
	}

	public void UpdateState () {
		Chase ();
	}

	public void ToPatrolState() {
		enemy.currentState = enemy.patrolState;
	}

	public void ToChaseState() {
		//Cant change to same state
	}

	public void ToDiedState(){
		enemy.currentState = enemy.diedState;
	}

    public void ToControlledState()
    {
		theController.SetDirectionalInput(new Vector2(0, 0));
		Debug.Log ("Pasando a ser controlado");
		enemy.currentState = enemy.controlledState;
    }

	void Chase() {

		Vector3 dir = enemy.target.position - enemy.transform.position;
		dir.z = 0.0f;

		if (dir != Vector3.zero) {
			enemy.transform.rotation = Quaternion.Slerp (enemy.transform.rotation, 
				Quaternion.FromToRotation (Vector3.right, dir), rotationSpeed * Time.deltaTime);
		}

        //enemy.transform.position += (enemy.target.position - enemy.transform.position).normalized * enemy.moveSpeed * Time.deltaTime;
        Vector3 moveDir = (enemy.target.position - enemy.transform.position).normalized;
        theController.SetDirectionalInput(moveDir);

        if (Vector3.Distance (enemy.transform.position, enemy.target.position) < 1f) {
			Debug.Log ("Dead");
		}
	}
}