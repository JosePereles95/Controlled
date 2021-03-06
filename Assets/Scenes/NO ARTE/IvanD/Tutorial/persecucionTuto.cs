﻿using System.Collections;
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
            SceneManager.LoadScene(1);
        }
    }

    void Update()
    {
        if (perseguir == true)
        {
            float step = speed * Time.deltaTime + (Time.deltaTime/1.3f);

            if (transform.position == wayPoints[next].position && next < wayPoints.Length -1)
                next++;

			if(next == 1 || next == 6 || next == 11)
            {
                anim.SetBool("isJumping", true);
            }
            else if (next == 4 || next == 9 || next == 14)
            {
                anim.SetBool("isJumping", false);
            }
            else if(next == 16)
                anim.SetBool("idle", true);

            transform.position = Vector3.MoveTowards(transform.position, wayPoints[next].position, step);
        }
    }
}
