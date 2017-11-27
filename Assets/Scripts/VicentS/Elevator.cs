using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
    public string rangoTag = "TripB"; //Etiqueta del rango del tripulante con el que se puede usar el ascensor

    public Elevator ascensorSuperior;
    public Elevator ascensorInferior;

    private void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == rangoTag)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) //Mover al ascensor de arriba
            {
                if (ascensorSuperior != null)
                    other.transform.position = ascensorSuperior.transform.position;
            }

            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) //Mover al ascensor de abajo
            {
                if (ascensorInferior != null)
                    other.transform.position = ascensorInferior.transform.position;
            }
        }
            
    }
}
