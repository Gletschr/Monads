using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomController : MonoBehaviour {

    public float zoomSpeed = 1.5f;
    public float minZoomSize = 1.0f;
    public float maxZoomSize = 20.0f;

    private Camera cam;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float newZoom = Camera.main.orthographicSize + scroll * -zoomSpeed;
        cam.orthographicSize = 
            Mathf.Clamp(newZoom, minZoomSize, maxZoomSize);
	}
}
