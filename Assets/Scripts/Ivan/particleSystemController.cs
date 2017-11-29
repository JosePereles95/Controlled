using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystemController : MonoBehaviour {
    private ParticleSystem pS;
    private Animator anim;
<<<<<<< HEAD
    public Material newMat;
=======
	private bool vomiting = true;
	private GameObject cambio;

>>>>>>> JoseP
	// Use this for initialization
	void Start () {
		cambio = GameObject.FindGameObjectWithTag ("cambioPersonaje");
        pS = GetComponent<ParticleSystem>();
        anim = GetComponentInParent<Animator>();
<<<<<<< HEAD
        pS.GetComponent< ParticleSystemRenderer > ().material = newMat;

=======
>>>>>>> JoseP
    }

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.V) && vomiting && !cambio.GetComponent<cambioPersonaje>().caida) { 
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
