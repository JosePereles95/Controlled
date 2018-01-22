using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objetivo : MonoBehaviour {

    private changeObjetivo descripcionObjetivo;
    public string descripcion;
    private bool activado = true;

	// Use this for initialization
	void Awake () {

        descripcionObjetivo = GameObject.FindGameObjectWithTag("Objetivo").GetComponent<changeObjetivo>();

		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && activado)
        {
            descripcionObjetivo.CambiarObjetivo(descripcion);
            activado = false;
        }
    }
}
