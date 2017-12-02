using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LimitesTutorial : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "AlienSalvaje")
        {
<<<<<<< HEAD:Assets/Scenes/NO ARTE/IvanD/Tutorial/LimitesTutorial.cs
            SceneManager.LoadScene(1);
=======
<<<<<<< HEAD
            SceneManager.LoadScene(0);
=======
            SceneManager.LoadScene(1);
>>>>>>> JoseP
>>>>>>> a8f1a5bf6eac4acc03c23fb766740b2a75af9274:Assets/Scenes/IvanD/Tutorial/LimitesTutorial.cs
        }
    }
}
