using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystemController : MonoBehaviour {
    private ParticleSystem pS;
<<<<<<< HEAD
 //   private Animation anim;
=======
>>>>>>> origin/JoseP
    
	// Use this for initialization
	void Start () {
        pS = GetComponent<ParticleSystem>();
<<<<<<< HEAD
    }
=======
	}
>>>>>>> origin/JoseP
	
	// Update is called once per frame
	void Update () {

<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.V)) { 
            if (pS.isEmitting)
            {
                pS.Stop();
             //   anim.Play("idle");
=======
        if (Input.GetKeyDown("v")) {
            if (pS.isEmitting)
            {
                pS.Stop();
>>>>>>> origin/JoseP
                Debug.Log("Stopping particle system");
            }
            else {
                pS.Play();
<<<<<<< HEAD
             //   anim.Play("Vomit");
=======
>>>>>>> origin/JoseP
                Debug.Log("Playing particle system");
            }
        }
	}
}
