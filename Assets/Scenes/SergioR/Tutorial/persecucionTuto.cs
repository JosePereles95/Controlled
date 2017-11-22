using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class persecucionTuto : MonoBehaviour {

    public Transform[] wayPoints;
    public float speed;
    public static bool perseguir = false;

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AlienSalvaje" && perseguir == true)
        {
            SceneManager.LoadScene(0);
        }
    }

    void Update()
    {
        if (perseguir == true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[0].position, step);
        }
    }
}
