using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistema_Juego : MonoBehaviour {

    public GameObject Checkpoint_Actual;
    private PlayerInput player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerInput>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void RespawnPlayer()
    {
        Debug.Log("Player Respawn");
        player.transform.position = Checkpoint_Actual.transform.position;
		if(player.playerState == PlayerInput.VujStates.Controlling)
			player.Desparasitar ();
    }
 
}
