using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_ChangeLevel : MonoBehaviour {

    public int boton = 0;

    public void Change_Lvl()
    {

        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Scene: " + scene.name);
        Debug.Log("Scene Path: " + scene.path);

        if (scene == SceneManager.GetSceneByBuildIndex(0)) //Si se está en el menú principal, ir al nivel 1
        {
            SceneManager.LoadScene(1);
        }

        if (scene == SceneManager.GetSceneByBuildIndex(1)) //Si se está en el nivel 1, ir al nivel 2
        {
            SceneManager.LoadScene(2);
        }

        if (scene == SceneManager.GetSceneByBuildIndex(2)) //Si se está en el nivel 2, ir al nivel 3
        {
            SceneManager.LoadScene(3);
        }

        if (scene == SceneManager.GetSceneByBuildIndex(3)) //Si se está en el nivel 3, ir a la pantalla de victoria.
        {
            SceneManager.LoadScene(5);
        }
        if (scene == SceneManager.GetSceneByBuildIndex(5)) //Si se está en la pantalla de victoria, volver al menú principal
        {
            SceneManager.LoadScene(0);
        }

        //Queda por hacer: Decidir si queremos una escena entera dedicada al menú de pausa.


    }

    public void Goto_Lvl_1()//ir al nivel 1
    {
        SceneManager.LoadScene(1);
    }

    public void Goto_Lvl_2()//ir al nivel 2
    {
        SceneManager.LoadScene(2);
    }

    public void Goto_Lvl_3()//ir al nivel 3
    {
        SceneManager.LoadScene(3);
    }

    public void Goto_MainMenu()//ir al Menú Principal
    {
        SceneManager.LoadScene(0);
    }

    public void Goto_VictoryScreen()//ir a la pantalla de victoria
    {
        SceneManager.LoadScene(5);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            Debug.Log("TOUCH");
            Change_Lvl();
        }
    }
}
