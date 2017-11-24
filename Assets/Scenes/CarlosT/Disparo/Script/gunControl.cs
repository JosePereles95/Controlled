using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunControl : MonoBehaviour {
    Rigidbody2D rb;
    Vector2 dir;
    float angle;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        dir = Input.mousePosition - transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);
	}
}
