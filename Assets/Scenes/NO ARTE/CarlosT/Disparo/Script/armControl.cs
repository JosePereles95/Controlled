using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armControl : MonoBehaviour {
    Rigidbody2D armRigidbody;               // Reference to the arm's rigidbody.
    int obstacleMask;                       // A layer mask so that a ray can be cast just at gameobjects on the obstacle layer.
    float camRayLength = 100f;              // The length of the ray from the camera into the scene.

	// Use this for initialization
	void Awake () {
        // Create a layer mask for the obstacle layer
        obstacleMask = LayerMask.GetMask("Obstacle");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Turning();
	}

    void Turning()
    {
        // Cretate a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Create a RaycastHit variable to store information aboput what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if(Physics.Raycast (camRay, out floorHit, camRayLength, obstacleMask))
        {
            // Create a vector from the player to the point on the obstacle from the mouse hit.
            Vector3 playerMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the wall plane
            playerMouse.z = 0f;

            // Create  a quaternion (rotation) base on looking down the vector from the arm to the mouse.
            Quaternion newRotation = Quaternion.LookRotation (playerMouse);

            //Set the armRotation to this new rotation.
            // ------------------------------ Error con el quaternion------------------
            // armRigidbody.MoveRotation(newRotation);
        }
    }
  
}
