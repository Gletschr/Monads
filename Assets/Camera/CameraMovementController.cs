using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour {

    private Vector3 mouseOriginPos;
    private Vector3 cameraOriginPos;

    private Camera cam;

    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1)) {
            mouseOriginPos = Input.mousePosition;
            cameraOriginPos = cam.transform.position;
        } else if (Input.GetMouseButton(1)) {
            float movementSpeed = cam.orthographicSize / 240.0f;
            float dx = mouseOriginPos.x - Input.mousePosition.x;
            float dy = mouseOriginPos.y - Input.mousePosition.y;
            float newCameraPosX = cameraOriginPos.x + dx * movementSpeed;
            float newCameraPosY = cameraOriginPos.y + dy * movementSpeed;
            transform.position = 
                new Vector3(newCameraPosX, newCameraPosY, transform.position.z);
        }
	}
}
