using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class persecucionTuto : MonoBehaviour {

    public Transform[] wayPoints;
    public float speed;
    public static bool perseguir = false;
    int next = 0;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
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
            float step = speed * Time.deltaTime + Time.deltaTime;

            if (transform.position == wayPoints[next].position && next < wayPoints.Length -1)
                next++;

            if(next == 1 || next == 9)
                anim.SetBool("isJumping", true);
            else if(next == 7 || next == 15 || next == 23)
                anim.SetBool("isJumping", false);
            else if(next == 25)
                anim.SetBool("idle", true);

            transform.position = Vector3.MoveTowards(transform.position, wayPoints[next].position, step);
        }
    }
}
