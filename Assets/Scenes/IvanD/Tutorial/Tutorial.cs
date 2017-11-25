using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public Renderer rend;
    public GameObject doctorTuto;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "AlienSalvaje")
        {
            rend.enabled = true;
            persecucionTuto.perseguir = true;
            doctorTuto.SetActive(true);
        }
    }
}
