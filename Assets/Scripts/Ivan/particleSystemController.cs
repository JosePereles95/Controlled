using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSystemController : MonoBehaviour {
    private ParticleSystem pS;
 //   private Animation anim;
    
	// Use this for initialization
	void Start () {
        pS = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.V)) { 
            if (pS.isEmitting)
            {
                pS.Stop();
             //   anim.Play("idle");
                Debug.Log("Stopping particle system");
            }
            else {
                pS.Play();
             //   anim.Play("Vomit");
                Debug.Log("Playing particle system");
            }
        }
	}
}
