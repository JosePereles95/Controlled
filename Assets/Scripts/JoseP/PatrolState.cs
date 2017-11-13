using System.Collections;
using UnityEngine;

public class PatrolState : IEnemyState {

	StateEnemyBehavior enemy;
	int nextWayPoint = 0;

	public Transform target;
	public int moveSpeed = 4;
	public int rotationSpeed = 0;

	public PatrolState (StateEnemyBehavior enemy) {
		this.enemy = enemy;
	}

	public void UpdateState () {
		target = enemy.wayPoints [nextWayPoint];

		Patrol ();
	}

	public void ToPatrolState() {
		//Cant change to same state
	}

	void Patrol() {
		
		Vector3 dir = target.position - enemy.transform.position;
		dir.z = 0.0f;

		if (dir != Vector3.zero) {
			
			enemy.transform.rotation = Quaternion.Slerp (enemy.transform.rotation, 
				Quaternion.FromToRotation (Vector3.right, dir), rotationSpeed * Time.deltaTime);
		}

		enemy.transform.position += (target.position - enemy.transform.position).normalized * moveSpeed * Time.deltaTime;
		Debug.Log ("MOVING");
		if (Vector3.Distance (enemy.transform.position, enemy.wayPoints [nextWayPoint].position) < 1f) {
			Debug.Log ("Change");
			if (nextWayPoint < enemy.wayPoints.Length - 1)
				nextWayPoint++;
			else
				nextWayPoint = 0;
		}
	}
}
