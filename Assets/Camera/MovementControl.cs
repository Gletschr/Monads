using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour {

    public float movementSpeed = 0.05f;
    private Vector3 mouseOriginPos;
    private Vector3 cameraOriginPos;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            mouseOriginPos = Input.mousePosition;
            cameraOriginPos = transform.position;
        } else if (Input.GetMouseButton(0)) {
            float dx = mouseOriginPos.x - Input.mousePosition.x;
            float dy = mouseOriginPos.y - Input.mousePosition.y;
            float newCameraPosX = cameraOriginPos.x + dx * movementSpeed;
            float newCameraPosY = cameraOriginPos.y + dy * movementSpeed;
            transform.position = 
                new Vector3(newCameraPosX, newCameraPosY, transform.position.z);
        }
	}
}
