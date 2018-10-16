using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour {

    public float movementSpeed = 0.02f;
    private Vector3 mouseOrigin;
    private float cameraOriginDx = 0.0f;
    private float cameraOriginDy = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            mouseOrigin = Input.mousePosition;
            cameraOriginDx = transform.position.x - mouseOrigin.x;
            cameraOriginDy = mouseOrigin.y - transform.position.y;
        } else if (Input.GetMouseButton(0)) {
            float dx = Input.mousePosition.x - mouseOrigin.x - cameraOriginDx;
            float dy = Input.mousePosition.y - mouseOrigin.y - cameraOriginDy;
            transform.position = new Vector3(dx * -movementSpeed, dy * -movementSpeed, transform.position.z);
        }
	}
}
