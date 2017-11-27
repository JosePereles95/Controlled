using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LimitesTutorial : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AlienSalvaje")
        {
<<<<<<< HEAD
            SceneManager.LoadScene(0);
=======
            SceneManager.LoadScene(1);
>>>>>>> JoseP
        }
    }
}
