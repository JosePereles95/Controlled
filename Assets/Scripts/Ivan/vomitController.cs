﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vomitController : MonoBehaviour {
    public GameObject vomito;
	public Transform vomitPos;

	private GameObject cambio;
    private bool vomiting = true;
    private bool jumping = false;

    //Sonido
    public AudioClip vomitsound;
    AudioSource fuenteAudio;

    private float time = 0.0f;

    // Use this for initialization
    void Start () {
        fuenteAudio = GetComponent<AudioSource>();

        cambio = GameObject.FindGameObjectWithTag ("cambioPersonaje");
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space)){
            jumping = true;
            time = 0.0f;
        }

        if (time > 2f){
            jumping = false;
        }

		if (vomiting && Input.GetKeyDown(KeyCode.F) && !jumping && !cambio.GetComponent<cambioPersonaje>().caida){
            fuenteAudio.clip = vomitsound;
            fuenteAudio.Play();
            Vomit ();
        }
    }
	
	public void Vomit(){
		GameObject clon = Instantiate(vomito, transform.position, transform.rotation) as GameObject;
		vomiting = false;
		StartCoroutine (Wait());
		clon.transform.position = vomitPos.transform.position;
		Destroy(clon, 4);
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (4);
		vomiting = true;
	}
}