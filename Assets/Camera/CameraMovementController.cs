using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour {

    private Vector3 mouseOriginWorldPos;

    private Camera cam;

    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1)) {
            mouseOriginWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        } else if (Input.GetMouseButton(1)) {
            float movementSpeed = 1.0f;
            Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
            float dx = mouseOriginWorldPos.x - mouseWorldPos.x;
            float dy = mouseOriginWorldPos.y - mouseWorldPos.y;
            float newCameraPosX = transform.position.x + dx * movementSpeed;
            float newCameraPosY = transform.position.y + dy * movementSpeed;
            transform.position = 
                new Vector3(newCameraPosX, newCameraPosY, transform.position.z);
        }
	}
}
