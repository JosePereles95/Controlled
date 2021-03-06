﻿using System.Collections;
using UnityEngine;

public class PatrolState : IEnemyState {

	StateEnemyBehavior enemy;
	int nextWayPoint = 0;

	public int rotationSpeed = 0;

	private bool facingRight = false;
	
    private float time = 0.0f;
    private bool stopping = false;

    private NpcMovement theController;

	public PatrolState (StateEnemyBehavior enemy, NpcMovement controller) {
		this.enemy = enemy;
        theController = controller;
	}

	public void UpdateState () {
        if (stopping)
        {
            time += Time.deltaTime;
            if (time > 22f)
            {
               enemy.moveSpeed = 4;
                stopping = false;
            }
        }
        else { enemy.moveSpeed = 4; }

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
        theController.SetDirectionalInput(new Vector2(0, 0));
        enemy.currentState = enemy.controlledState;
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

		/*if (((enemy.target.position - enemy.transform.position).normalized).x > 0)
			FlipDroide (1);
		else
			FlipDroide (-1);*/

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
    private void OnTriggerEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "vomit")
        {
            Debug.Log("TRIGGERED");
            enemy.moveSpeed = 0;
            stopping = true;
            time = 0.0f;
        }
    }
}