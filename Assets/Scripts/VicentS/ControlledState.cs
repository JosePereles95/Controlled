using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledState : IEnemyState {

    StateEnemyBehavior enemy;

    private NpcMovement theController;
    private float damagePerSecond = 10f;

    public ControlledState (StateEnemyBehavior enemy, NpcMovement controller)
    {
        this.enemy = enemy;
        theController = controller;
    }

    public void UpdateState()
    {
        Controlled();
    }

    public void ToPatrolState()
    {
       // enemy.currentState = enemy.patrolState;
    }

    public void ToChaseState()
    {
        //enemy.currentState = enemy.chaseState;
    }

    public void ToControlledState()
    {
        //Cant change to the same state
    }

    private void Controlled()
    {
        if (enemy.controlled)
        {
            enemy.TakeDamage(damagePerSecond * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.E))
                enemy.Desparasitar();
        }
    }
}
