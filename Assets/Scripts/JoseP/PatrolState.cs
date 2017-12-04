using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState {

	StateEnemyBehavior enemy;
	private NpcMovement theController;

	public int nextWayPoint = 0;
	public int rotationSpeed = 0;
	private bool facingRight = false;

    public PatrolState (StateEnemyBehavior enemy, NpcMovement controller) {
		this.enemy = enemy;
		enemy.moveSpeed = 4;
        theController = controller;
	}

	public void UpdateState () {
		enemy.target = enemy.wayPoints [nextWayPoint];

		Patrol ();
	}

	public void ToPatrolState() {
		//Cant change to same state
	}

	public void ToChaseState() {
		enemy.currentState = enemy.chaseState;
	}

    public void ToControlledState()
    {
		//Debug.Log ("Pasando a ser controlado");
        enemy.currentState = enemy.controlledState;
    }

	public void ToDiedState(){
		enemy.currentState = enemy.diedState;
	}

	private void Patrol() {

        Vector3 dir = enemy.target.position - enemy.transform.position;
		dir.z = 0.0f;

		if (dir != Vector3.zero) {
			enemy.transform.rotation = Quaternion.Slerp (enemy.transform.rotation, 
				Quaternion.FromToRotation (Vector3.right, dir), rotationSpeed * Time.deltaTime);
		}

        //enemy.transform.position += (enemy.target.position - enemy.transform.position).normalized * enemy.moveSpeed * Time.deltaTime;

        Vector3 movementDir = (enemy.target.position - enemy.transform.position).normalized;
        theController.SetDirectionalInput(movementDir);


		if (Vector3.Distance (enemy.transform.position, enemy.wayPoints [nextWayPoint].position) < 1f) {
			if (nextWayPoint < enemy.wayPoints.Length - 1)
				nextWayPoint++;
			else
				nextWayPoint = 0;
		}
	}

	private void FlipDroide(float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
		{
			facingRight = !facingRight;

			Vector3 theScale = enemy.transform.localScale;
			float thePosition = enemy.transform.localPosition.x;

			enemy.transform.localPosition = new Vector3(thePosition, enemy.transform.localPosition.y, enemy.transform.localPosition.z);

			theScale.x *= -1;
			enemy.transform.localScale = theScale;
		}
	}
}