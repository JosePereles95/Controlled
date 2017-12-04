using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiedState : IEnemyState {

	StateEnemyBehavior enemy;
	private NpcMovement theController;

	public DiedState (StateEnemyBehavior enemy, NpcMovement controller)
	{
		this.enemy = enemy;
		theController = controller;
	}

	public void UpdateState()
	{
		Died();
	}

	public void ToPatrolState(){
		
	}

	public void ToChaseState(){
		
	}

	public void ToControlledState(){
		
	}

	public void ToDiedState(){
		//Cant change to the same state
	}

	private void Died(){
		if (!enemy.muerto) {
			enemy.GetComponent<Animator> ().SetBool("isDead", true);
			enemy.muerto = true;
            GameObject.FindObjectOfType<Sistema_Jueg>().SpawnCharacter(enemy.spawnPoint);
            enemy.StartCoroutine("Respawn");
		}
	}
}