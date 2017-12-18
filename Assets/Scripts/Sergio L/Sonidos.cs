using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour {

    //1 Se añade un componente AudioSource al elemento que va ha hacer el sonido.
    //2 Se crean variables para los sonidos que va a hacer.
    public AudioClip salto;
    public AudioClip andar;
    AudioSource fuenteAudio;

    // Use this for initialization
    void Start () {

        // 3 Se guarda en una variable el componente.
        fuenteAudio = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //4 Se asigna el audio que va a sonar por el AudioSource y luego se le hace .Play.
            fuenteAudio.clip = salto;
            fuenteAudio.Play();

        }
		
	}
}
