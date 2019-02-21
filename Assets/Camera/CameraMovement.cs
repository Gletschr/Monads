using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    Camera cam;

    private Vector3 mouseOriginWorldPos;

    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(1)) {
            mouseOriginWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        } else if (Input.GetMouseButton(1)) {
            Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
            float dx = mouseOriginWorldPos.x - mouseWorldPos.x;
            float dy = mouseOriginWorldPos.y - mouseWorldPos.y;
            float newCameraPosX = transform.position.x + dx;
            float newCameraPosY = transform.position.y + dy;
            transform.position = 
                new Vector3(newCameraPosX, newCameraPosY, transform.position.z);
        }
    }
}
