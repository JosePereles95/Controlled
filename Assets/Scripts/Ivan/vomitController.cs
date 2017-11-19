using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vomitController : MonoBehaviour {
    public int duration = 2;
    private Animator anim;
    //public SkinnedMeshRenderer sr;
    public Player p;
    public GameObject g;
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
        this.enabled = false;
        jumping = false;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        timeVomiting += Time.deltaTime;
      //this.transform.position = new Vector2(p.transform.position.x + 5, p.transform.position.y);
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
          //this.GetComponentInChildren<SpriteRenderer>().enabled = true;

        }
        if (timeVomiting > 2f && vomiting) {
            Disappear();
            Debug.Log("Va a destruirlo");
            Destroy(g);
            Debug.Log("Destruido");
        }

        if (vomiting && jumping)
        {
            timeVomiting = 0.0f;
            vomiting = false;
        //  this.enabled = false;
        //this.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }

     /* if (vomiting)
            Appear();
        else if (jumping || !vomiting)
            Disappear();*/

        if (Input.GetKeyDown("v") && !jumping)
        {
            anim.enabled = true;
            Debug.Log("Va a vomitar");
            anim.Play("Vomit");
            Debug.Log("Vomitaaa");
            /* this.enabled = true;
               this.transform.position = new Vector2(p.transform.position.x + 5, p.transform.position.y);
               this.GetComponentInChildren<SpriteRenderer>().enabled = true;*/
            g = Instantiate(g);
            g.transform.position = new Vector2(p.transform.position.x + 5, p.transform.position.y);
            Debug.Log("Creado charco");
        }

        
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
    void Appear()
    {
        this.GetComponent<SkinnedMeshRenderer>().enabled = true;
        
        this.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, timeVomiting / duration));
        this.enabled = true;
    }

    void Disappear()
    {
       
      this.GetComponent<SkinnedMeshRenderer>().enabled = false;

      this.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, timeVomiting / duration));
        this.enabled = false;
    }
    
}
