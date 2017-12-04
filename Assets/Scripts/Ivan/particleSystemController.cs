using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystemController : MonoBehaviour {
    private ParticleSystem pS;
    private Animator anim;
	private bool vomiting = true;
	private GameObject cambio;
	private bool jumping = false;
	private float time = 0.0f;

	// Use this for initialization
	void Start () {
		cambio = GameObject.FindGameObjectWithTag ("cambioPersonaje");
        pS = GetComponent<ParticleSystem>();
        anim = GetComponentInParent<Animator>();
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

		if (Input.GetKeyDown(KeyCode.V) && vomiting && !jumping && !cambio.GetComponent<cambioPersonaje>().caida) { 
			vomiting = false;
			StartCoroutine (Wait());

            if (pS.isEmitting)
            {
                pS.Stop();
                anim.Play("Idle");
            }
            else {
                pS.Play();
                anim.Play("Vomit");
            }
        }
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (4);
		vomiting = true;
	}
}
