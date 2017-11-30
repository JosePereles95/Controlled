using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
    public string tagSubir = ""; //Etiqueta del rango del tripulante con el que se puede subir en el ascensor
    public string tagBajar = "";        //Etiqueta del rango del tripulante con el que se puede bajar en el ascensor

    public Elevator ascensorSuperior;
    public Elevator ascensorInferior;

    public List<Sprite> botonesSubir;
    public List<Sprite> botonesBajar;

    public SpriteRenderer botonSuperior;
    public SpriteRenderer botonInferior;

    public Transform teleportPoint;

    private void Start()
    {
        ColocarBotonInferior();
        ColocarBotonInferior();
    }

    public void CambiarTagSubir(string tag)
    {
        tagSubir = tag;
        ColocarBotonSuperior();
    }

    public void CambiarTagInferior(string tag)
    {
        tagBajar = tag;
        ColocarBotonInferior();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == tagSubir)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) //Mover al ascensor de arriba
            {
                if (ascensorSuperior != null)
                    other.transform.position = ascensorSuperior.teleportPoint.position;
            }
        }
        
        if (other.tag == tagBajar)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) //Mover al ascensor de arriba
            {
               ;
                if (ascensorInferior != null)
                    other.transform.position = ascensorInferior.teleportPoint.position;
            }
        }

        Debug.Log(other.tag);
        Debug.Log(tagBajar);


    }

    private void ColocarBotonSuperior()
    {
        if (ascensorSuperior != null)
        {
            if (!botonSuperior.gameObject.activeInHierarchy)
                botonSuperior.gameObject.SetActive(true);

            CambiarColorBotonSuperior();
        }
        else
            botonSuperior.gameObject.SetActive(false);
        
    }

    private void CambiarColorBotonSuperior()
    {
        switch(tagSubir)
        {
            case "Tripulante":
                botonSuperior.sprite = botonesSubir[0];
                break;
            case "TripulanteAlien":
                botonSuperior.sprite = botonesSubir[1];
                break;
            case "TripulanteIngeniera":
                botonSuperior.sprite = botonesSubir[2];
                break;
            case "Doctor":
                botonSuperior.sprite = botonesSubir[3];
                break;
            case "Todos":
                botonSuperior.sprite = botonesSubir[4];
                break;
        }
    }

    private void ColocarBotonInferior()
    {
        if (ascensorInferior != null)
        {
            if (!botonInferior.gameObject.activeInHierarchy)
                botonInferior.gameObject.SetActive(true);

            CambiarColorBotonInferior();
        }
        else
            botonInferior.gameObject.SetActive(false);
    }

    private void CambiarColorBotonInferior()
    {
        switch (tagBajar)
        {
            case "Tripulante":
                botonInferior.sprite = botonesBajar[0];
                break;
            case "TripulanteAlien":
                botonInferior.sprite = botonesBajar[1];
                break;
            case "TripulanteIngeniera":
                botonInferior.sprite = botonesBajar[2];
                break;
            case "Doctor":
                botonInferior.sprite = botonesBajar[3];
                break;
            case "Todos":
                botonInferior.sprite = botonesBajar[4];
                break;
        }
    }
}
