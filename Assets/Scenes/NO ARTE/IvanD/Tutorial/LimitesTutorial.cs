using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LimitesTutorial : MonoBehaviour {

<<<<<<< HEAD
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AlienSalvaje")
=======
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "AlienSalvaje")
>>>>>>> JoseP
        {
            SceneManager.LoadScene(1);
        }
    }
}
