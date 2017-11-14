using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vomitController : MonoBehaviour {
    private Animator anim;
  //  public SpriteRenderer sr;
    private bool vomiting = false;
  //  private bool vomitlake = false;
    private int cont;
  //  private int cont2;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
       if (cont == 60 && vomiting) {
            anim.Play("idle");
            vomiting = false;
          //  sr.enabled = true;
          //sr.SetActive(true);
          //  vomitlake = true;
        }
        if (vomiting) {
            cont += 1;
        }
       /* if (vomitlake) {
            cont2 += 1;
        }
       if (cont2 == 5) {
            sr.enabled = false;
         // sr.SetActive(false);
        }*/
        if (Input.GetKeyDown("v")) {
            anim.enabled = true;
            anim.Play("Vomit");
            vomiting = true;
            cont = 0;
        }
    }
}
