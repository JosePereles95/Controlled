using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaVertical : MonoBehaviour {

    public Animator anim;

    public bool Vuj;
    public bool tripulante;
    public bool tripulanteAlien;
    public bool tripulanteIngeniera;
    public bool droide;
    public bool robot;
    public bool mono;
    public bool gato;

    bool doorOpen;

    // Use this for initialization
    void Start ()
    {
        doorOpen = false;
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && Vuj || 
            col.gameObject.tag == "Tripulante" && tripulante ||
            col.gameObject.tag == "TripulanteAlien" && tripulanteAlien ||
            col.gameObject.tag == "TripulanteIngeniera" && tripulanteIngeniera ||
            col.gameObject.tag == "Droide" && droide ||
            col.gameObject.tag == "Robot" && robot ||
            col.gameObject.tag == "Mono" && mono ||
            col.gameObject.tag == "Gato" && gato)
        {
            doorOpen = true;
            DoorControl("Open");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (doorOpen)
        {
            doorOpen = false;
            DoorControl("Close");
        }
    }

    void DoorControl(string direction)
    {
        anim.SetTrigger(direction);
    }
}
