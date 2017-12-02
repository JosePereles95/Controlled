using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herir_Jugador : MonoBehaviour {

    public Sistema_Jueg levelManager;

    // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<Sistema_Jueg>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            levelManager.RespawnPlayer();
        }
        
    }
}
