﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    Animator anim;

    private LineRenderer lr;
    private Transform lrPos;

    public GameObject bullet;
    public LayerMask layerMask;
    float range = 100f;

    Vector2 direccion;

    void Start()
    {
        lr = bullet.GetComponent<LineRenderer>();
        lrPos = bullet.GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        Vector2 firePos = new Vector2(lrPos.position.x, lrPos.position.y);

        if (this.transform.localScale.x > 0)
        {
            direccion = new Vector2(-1, -0.2f);
        }
        else
        {
            direccion = new Vector2(1, -0.2f);
        }

        RaycastHit2D hit = Physics2D.Raycast(firePos, direccion, range, layerMask);

        //Debug.DrawRay(firePos, direccion * range, Color.blue, 1f);

        if (hit.collider)
        {
            lr.SetPosition(1, new Vector3(hit.distance, 0, 0));
        }
        else
        {
            lr.SetPosition(1, new Vector3(100, 0, 0));
        }

        if (hit.collider.gameObject.tag == "Player")
        {
            print("Estas muerto. Laser.");
        }
    }

}
