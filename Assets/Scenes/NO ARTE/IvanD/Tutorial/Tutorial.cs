using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public Renderer rend;
    public GameObject text;
    public GameObject doctorTuto;

    Animator anim;

    void Start()
    {
        rend = GetComponent<Renderer>();
        anim = GetComponent<Animator>();

        rend.enabled = false;
        text.GetComponent<Renderer>().enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "AlienSalvaje")
        {
            rend.enabled = true;
            text.GetComponent<Renderer>().enabled = true;
            anim.SetBool("start", true);
            persecucionTuto.perseguir = true;
            doctorTuto.SetActive(true);
        }
    }
}
