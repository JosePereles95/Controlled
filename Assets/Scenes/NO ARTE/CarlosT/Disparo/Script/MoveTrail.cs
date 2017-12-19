using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour {

	public int moveSpeed = 100;
	public float damage = 50;

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
		Destroy(gameObject, 10);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			PlayerInput player = collision.GetComponent<PlayerInput>();
			if (player.playerState != PlayerInput.VujStates.Controlling)
			{
				FindObjectOfType<Sistema_Jueg>().RespawnPlayer();
			}
		}
		else
		{
			StateEnemyBehavior npc = collision.GetComponent<StateEnemyBehavior>();
			if (npc != null)
			{
				npc.TakeDamage(damage);
			}
		}

		Destroy(gameObject);
	}
}
