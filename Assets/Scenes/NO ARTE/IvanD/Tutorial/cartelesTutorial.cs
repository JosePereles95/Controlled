using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartelesTutorial : MonoBehaviour {

    public GameObject tutorial;
    [HideInInspector]public Renderer rend;
    bool soloUnaVez = true;

    void Start()
    {
        tutorial = GetComponent<GameObject>();
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && soloUnaVez == true)
        {
            rend.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rend.enabled = false;
            soloUnaVez = false;
        }
        if (this.gameObject.name == "Teclas_1")
        {
            tutorial.SetActive(false);
        }
    }
}
