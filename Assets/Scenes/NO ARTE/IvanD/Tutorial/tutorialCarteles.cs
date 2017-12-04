using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialCarteles : MonoBehaviour {

    public GameObject AlienSalvaje;
    public GameObject VUJ;
    public GameObject tutorial;
	public GameObject Tripulante;
	public GameObject barrera;

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
			//Tripulante.SetActive (true);
            this.gameObject.SetActive(false);
			barrera.SetActive (false);
            tutorial.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) == true && this.name == "cartelVUJ")
        {
			VUJ.SetActive(true);
			monoTutorial.moverse = true;
            this.gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) == true && this.name == "cartelFIN")
        {
            this.gameObject.SetActive(false);
			SceneManager.LoadScene(2);
        }
    }

}
