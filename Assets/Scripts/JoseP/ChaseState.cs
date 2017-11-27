using System.Collections;
using UnityEngine;

public class ChaseState : IEnemyState {

	StateEnemyBehavior enemy;

	public int rotationSpeed = 0;
    private NpcMovement theController;

	public ChaseState (StateEnemyBehavior enemy, NpcMovement controller) {
		this.enemy = enemy;
        theController = controller;
	}

	public void UpdateState () {
		enemy.moveSpeed = 5;
		Chase ();
	}

	public void ToPatrolState() {
		enemy.currentState = enemy.patrolState;
	}

	public void ToChaseState() {
		//Cant change to same state
	}

    public void ToControlledState()
    {
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