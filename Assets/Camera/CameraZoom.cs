using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    Camera cam;

    private const float minZoomValue = 1.0f;

    [Range(minZoomValue, 20.0f)]
    public float maxZoomValue = 20.0f;

    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
    }
    
    // Update is called once per frame
    void Update () {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float speed = (cam.orthographicSize / maxZoomValue) * 100.0f;
        float newZoom = Camera.main.orthographicSize + scroll * -speed;
        cam.orthographicSize = 
            Mathf.Clamp(newZoom, minZoomValue, maxZoomValue);
    }
}
