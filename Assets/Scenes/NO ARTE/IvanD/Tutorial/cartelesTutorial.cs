using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartelesTutorial : MonoBehaviour {

<<<<<<< HEAD
    public GameObject tutorial;
    [HideInInspector]public Renderer rend;
    bool soloUnaVez = true;

    void Start()
    {
        tutorial = GetComponent<GameObject>();
        rend = GetComponent<Renderer>();
=======
    [HideInInspector] public Renderer rend;
	private GameObject tutorial;
    private bool soloUnaVez = true;

    void Start()
    {
		tutorial = GameObject.FindGameObjectWithTag ("Tutorial").GetComponent<GameObject>();
        rend = this.GetComponent<SpriteRenderer>();
>>>>>>> JoseP
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
<<<<<<< HEAD
        if (this.gameObject.name == "Teclas_1")
=======
        if (this.gameObject.name == "Player")
>>>>>>> JoseP
        {
            tutorial.SetActive(false);
        }
    }
}
