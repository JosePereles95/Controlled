using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
    public string tagSubir; //Etiqueta del rango del tripulante con el que se puede subir en el ascensor
    public string tagBajar;        //Etiqueta del rango del tripulante con el que se puede bajar en el ascensor

    public Elevator ascensorSuperior;
    public Elevator ascensorInferior;

    public List<Sprite> botonesSubir;
    public List<Sprite> botonesBajar;

    public SpriteRenderer botonSuperior;
    public SpriteRenderer botonInferior;

    private void Awake()
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
                    other.transform.position = ascensorSuperior.transform.position;
            }
        }

        else if(other.tag == tagBajar)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) //Mover al ascensor de arriba
            {
                if (ascensorSuperior != null)
                    other.transform.position = ascensorSuperior.transform.position;
            }
        }
            
    }

    private void ColocarBotonSuperior()
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
