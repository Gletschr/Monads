using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonadMovement : MonoBehaviour {

    MonadBrain brain;

	// Use this for initialization
	void Start () {
        brain = GetComponent<MonadBrain>();
	}
	
	// Update is called once per frame
	void Update () {
        float speed = brain.GetMovementSpeed() * 0.1f;
        Vector3 pos = transform.position;
        Vector3 targetPos = pos + brain.GetMovementDirection();
        transform.position = Vector3.MoveTowards(pos, targetPos, speed);
    }
}
