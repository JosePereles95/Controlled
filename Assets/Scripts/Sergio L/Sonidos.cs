using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour {

    public AudioClip salto;
    public AudioClip andar;

    AudioSource fuenteAudio;

    // Use this for initialization
    void Start () {
        fuenteAudio = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            fuenteAudio.clip = salto;
            fuenteAudio.Play();

        }
		
	}
}
