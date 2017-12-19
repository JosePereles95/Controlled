using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muerte : MonoBehaviour {


	//Sonidos

	public AudioClip muerte;

	public AudioClip daño;
    AudioSource fuenteAudio;




	//

	public int vidas = 2;
	private float time = 0f;
	private float waitTime = 3f;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
		fuenteAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (vidas == 0) {
			Morir ();
		}

		if (Input.GetKeyDown(KeyCode.Minus)){
			RecibirDaño();
		}
	}

	void Morir(){

        fuenteAudio.clip = muerte;
        fuenteAudio.Play();

		anim.Play ("Death");
	}

	void RecibirDaño(){
		if (time > waitTime) {

			fuenteAudio.clip = daño;
			fuenteAudio.Play();

			vidas--;
			time = 0f;
		}
	}
}