using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herir_Jugador: MonoBehaviour {

    public Sistema_Jueg LevelManager;

    // Use this for initialization
    void Start()
    {
        LevelManager = FindObjectOfType<Sistema_Jueg>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player" || other.tag == "Tripulante")
        {
            LevelManager.RespawnPlayer();
        }
        
    }
}
