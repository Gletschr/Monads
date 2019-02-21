﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    Camera cam;

    // Movement by keyboard speed
    private float keyMovementSpeed;

    private Vector3 mouseOriginWorldPos;

    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
        keyMovementSpeed = cam.orthographicSize / 30.0F;
    }
    
    // Update is called once per frame
    void Update () {
        Vector3 deltaPosition = new Vector3();

        // Move camera by mouse
        if (Input.GetMouseButtonDown(1)) {
            mouseOriginWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        } else if (Input.GetMouseButton(1)) {
            Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
            float dx = mouseOriginWorldPos.x - mouseWorldPos.x;
            float dy = mouseOriginWorldPos.y - mouseWorldPos.y;
            deltaPosition = new Vector3(dx, dy, 0.0F);
        } else { // Move camera by keyboard
            if (Input.GetKey(KeyCode.W)) {
                deltaPosition = 
                    deltaPosition + new Vector3(0, keyMovementSpeed, 0);
            }
            if (Input.GetKey(KeyCode.S)) {
                deltaPosition =
                    deltaPosition + new Vector3(0, -keyMovementSpeed, 0);
            }
            if (Input.GetKey(KeyCode.A)) {
                deltaPosition =
                    deltaPosition + new Vector3(-keyMovementSpeed, 0, 0);
            }
            if (Input.GetKey(KeyCode.D)) {
                deltaPosition =
                    deltaPosition + new Vector3(keyMovementSpeed, 0, 0);
            }
        }

        transform.position = transform.position + deltaPosition;
    }
}
