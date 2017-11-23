using System.Collections;
using UnityEngine;

public class ChaseState : IEnemyState {

	StateEnemyBehavior enemy;

	public int rotationSpeed = 0;

	public ChaseState (StateEnemyBehavior enemy) {
		this.enemy = enemy;
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

    void Chase() {

		Vector3 dir = enemy.target.position - enemy.transform.position;
		dir.z = 0.0f;

		if (dir != Vector3.zero) {
			enemy.transform.rotation = Quaternion.Slerp (enemy.transform.rotation, 
				Quaternion.FromToRotation (Vector3.right, dir), rotationSpeed * Time.deltaTime);
		}

		enemy.transform.position += (enemy.target.position - enemy.transform.position).normalized * enemy.moveSpeed * Time.deltaTime;
		if (Vector3.Distance (enemy.transform.position, enemy.target.position) < 1f) {
			Debug.Log ("Dead");
		}
	}
}