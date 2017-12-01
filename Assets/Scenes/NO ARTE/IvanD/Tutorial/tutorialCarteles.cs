﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialCarteles : MonoBehaviour {

    public GameObject AlienSalvaje;
    public GameObject VUJ;
    public GameObject tutorial;
    public GameObject Tripulante;

    void Update ()
    {
        if (Input.GetMouseButtonDown(0) == true && this.name == "cartelTutorial")
        {
            this.gameObject.SetActive(false);
            AlienSalvaje.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) == true && this.name == "cartelPuertas")
        {
            VUJ.SetActive(true);
            Tripulante.SetActive(true);
            this.gameObject.SetActive(false);
            tutorial.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) == true && this.name == "cartelVUJ")
        {
            this.gameObject.SetActive(false);
            VUJ.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) == true && this.name == "cartelFIN")
        {
            this.gameObject.SetActive(false);
        }
    }

}
