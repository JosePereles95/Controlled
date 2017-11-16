using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (LineRenderer))]

public class laserRojo : MonoBehaviour {

    /*private LineRenderer lr;

	// Use this for initialization
	void Start ()
    {
        lr = GetComponent<LineRenderer>();
	}

    // Update is called once per frame
    void Update ()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.collider)
            {
                lr.SetPosition(1, new Vector3(hit.distance, 0, 0));
            }
        }
        else
        {
            lr.SetPosition(1, new Vector3(20, 0, 0));
        }
	}*/

    /*private LineRenderer lineRenderer;
    //public Transform laserHit;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        //lineRenderer.enabled = false;
        //lineRenderer.useWorldSpace = true;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up);
        //Debug.DrawLine(transform.position, hit.point);
        //laserHit.position = -hit.point;
    }*/

    void Update()
    {
        //If the left mouse button is clicked.
        if (Input.GetMouseButtonDown(0))
        {
            //Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            //If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
            }
        }
    }

}
