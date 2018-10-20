using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonadMovementController : MonoBehaviour {

    private MonadBrain brain;

	// Use this for initialization
	void Start () {
        brain = GetComponent<MonadBrain>();
    }
	
	// Update is called once per frame
	void Update () {
        float speed = brain.GetMovementSpeed();
        Vector3 targetPos = brain.GetMovementTargetPos();
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
