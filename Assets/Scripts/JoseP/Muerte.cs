using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muerte : MonoBehaviour {

	public int vidas = 2;
	private float time = 0f;
	private float waitTime = 3f;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
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
		anim.Play ("Death");
	}

	void RecibirDaño(){
		if (time > waitTime) {
			vidas--;
			time = 0f;
		}
	}
}