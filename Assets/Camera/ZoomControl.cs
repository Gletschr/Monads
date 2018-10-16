using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomControl : MonoBehaviour {

    public float speed = 1.5f;
    public float minZoomSize = 1.0f;
    public float maxZoomSize = 20.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float newZoom = Camera.main.orthographicSize + scroll * -speed;
        Camera.main.orthographicSize = Mathf.Clamp(newZoom, minZoomSize, maxZoomSize);
	}
}
