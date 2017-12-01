using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorCarteles : MonoBehaviour {

    public GameObject cartelTutorial;
    public GameObject cartelPuertas;
    public GameObject cartelVUJ;
    public GameObject cartelFIN;

    public GameObject AlienSalvaje;
    public GameObject VUJ;

    bool puerta = true;
    bool vuj = true;

    // Use this for initialization
    void Start () {
        cartelPuertas.SetActive(false);
        cartelVUJ.SetActive(false);
        cartelFIN.SetActive(false);
        cartelTutorial.SetActive(true);

        AlienSalvaje.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && this.name == "mostraCartelVUJ" && vuj == true)
        {
            cartelVUJ.SetActive(true);
            VUJ.SetActive(false);
            vuj = false;
        }

        if (collision.tag == "Player" && this.name == "mostraCartelPuertas" && puerta == true)
        {
            cartelPuertas.SetActive(true);
            VUJ.SetActive(false);
            puerta = false;
        }

    }
}
