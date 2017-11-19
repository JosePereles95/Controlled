using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vomitController : MonoBehaviour {
    public int duration = 2;
    public Player p;
    public GameObject[] v;
    public bool isVomiting;
    private bool vomiting = false;
    private bool jumping = false;
    private float minimum = 0f;
    private float maximum = 1f;

    private float time = 0.0f;
    private float timeVomiting = 0.0f;

    // Use this for initialization
    void Start () {
        jumping = false;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        timeVomiting += Time.deltaTime;
        if (Input.GetKeyDown("space"))
        {
            jumping = true;
            time = 0.0f;

        }

        if (time > 2f && !vomiting)
        {
            timeVomiting = 0.0f;
            vomiting = true;
            jumping = false;

        }
        if (timeVomiting >22f && vomiting) {
            Debug.Log("Eliminar");
            this.isVomiting = false;
            vomiting = false;
        }

        if (vomiting && jumping)
        {
            timeVomiting = 0.0f;
            vomiting = false;
        }

        if (!isVomiting && Input.GetKeyDown(KeyCode.V) && !jumping)
        {
            Debug.Log("Vomitaaa");
            GameObject clon = Instantiate(v[0], transform.position, transform.rotation) as GameObject;
            this.isVomiting = true;
            clon.transform.position = new Vector2(p.transform.position.x + 5, p.transform.position.y);
            Destroy(clon, 10);
            Debug.Log("Creado charco");
        }
    }
}
