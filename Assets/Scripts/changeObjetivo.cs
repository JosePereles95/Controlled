using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeObjetivo : MonoBehaviour {

    public Text descripcionObjetivo;

    public void CambiarObjetivo(string objetivo)
    {
        descripcionObjetivo.text = objetivo;
    }

}
