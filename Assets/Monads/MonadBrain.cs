using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Interpreter {

    public uint opcodeIndex = 0;


}

class MovementMemory {

    public float[] data = new float[3];

    public float GetPosX() {
        return data[1];
    }

    public void SetPosX(float value) {
        data[1] = value;
    }

    public float GetPosY() {
        return data[2];
    }

    public void SetPosY(float value) {
        data[2] = value;
    }

    public float GetSpeed() {
        return data[0];
    }

    public void SetSpeed(float value) {
        data[0] = value;
    }

}

public class MonadBrain : MonoBehaviour {

    // Movement
    private MovementMemory movementMem = new MovementMemory();

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        // Movement
        movementMem.SetSpeed(Random.Range(0.1f, 10.0f));
        movementMem.SetPosX(Random.Range(-100.0f, 100.0f));
        movementMem.SetPosY(Random.Range(-100.0f, 100.0f));
    }

    public float GetMovementSpeed() {
        return movementMem.GetSpeed();
    }

    public Vector3 GetMovementTargetPos() {
        return new Vector3(movementMem.GetPosX(), movementMem.GetPosY(), 0.0f);
    }

}
