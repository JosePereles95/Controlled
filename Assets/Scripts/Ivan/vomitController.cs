using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vomitController : MonoBehaviour {
    public int duration = 2;
    private Animator anim;
    //public SkinnedMeshRenderer sr;
    public GameObject sr;
    private bool vomiting = false;
 // private bool vomitlake = false;
    private bool jumping = false;
    private float minimum = 0f;
    private float maximum = 1f;
 // private int cont;
 // private int cont2;

    private float time = 0.0f;
    private float timeVomiting = 0.0f;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        sr = GetComponent<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        timeVomiting += Time.deltaTime;

        if (Input.GetKeyDown("Space"))
        {
            jumping = true;
            time = 0.0f;

        }

        if (time > 2f && !vomiting)
        {
            timeVomiting = 0.0f;
            anim.Play("idle");
            vomiting = true;
            jumping = false;
            // this.GetComponentInChildren<SpriteRenderer>().enabled = true;
            sr.SetActive(false);

        }

        if (vomiting && jumping)
        {
            timeVomiting = 0.0f;
            vomiting = false;
            // this.GetComponentInChildren<SpriteRenderer>().enabled = false;
            sr.SetActive(false);
        }

        if (vomiting)
            Appear();
        else if (jumping)
            Disappear();

        if (Input.GetKeyDown("v"))
        {
            anim.enabled = true;
            anim.Play("Vomit");
            vomiting = true;
            sr.SetActive(true);
        }

        if (sr.
        /*if (cont == 60 && vomiting) {
              anim.Play("idle");
              vomiting = false;
              sr.
              sr.enabled = true;
            //sr.SetActive(true);
            vomitlake = true;
          }
          if (vomiting) {
              cont += 1;
          }
          if (vomitlake) {
              cont2 += 1;
          }
         if (cont2 == 5) {
              //sr.enabled = false;
           sr.SetActive(false);
          }*/

    }
    void Disappear()
    {
           //his.GetComponent<SkinnedMeshRenderer>().enabled = true;
        sr.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;

     // this.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, timeVomiting / duration));
        sr.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, timeVomiting / duration));
    }

    void Appear()
    {
          //this.GetComponent<SkinnedMeshRenderer>().enabled = false;
        sr.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;

     // this.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, timeVomiting / duration));
        sr.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, timeVomiting / duration));
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "enemy") {
          //GameObject.Stop("enemy");
          //En los NPCs, if stop, time = 10f parados, después reanudar y destroy vomit
        }
    }
}
