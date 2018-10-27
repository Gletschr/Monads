using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MonadMemorySemantic {
    kMovementDirectionX = 0,
    kMovementDirectionY = 1,
    kMovementSpeed = 2,
}

public class MonadBrain : MonoBehaviour {

    byte[] dna;
    byte[] mem;

    long memptr = 0;
    long offset = 0;

    delegate void Asm(MonadBrain brain);

    static Asm[] asm = {
        Inc,
        Dec,
        IncPtr,
        DecPtr,
    };

    // Use this for initialization
    void Start () {
        mem = new byte[3];
        dna = new byte[Random.Range(10, 100)];
        for (int i = 0; i < dna.Length; ++ i) {
            dna[i] = (byte)Random.Range(0, asm.Length);
        }
    }
	
	// Update is called once per frame
	void Update () {
        asm[dna[offset]](this);
        if (offset >= dna.Length) {
            offset = offset - dna.Length;
        }
	}
 
    public float GetMovementSpeed() {
        return mem[(int)MonadMemorySemantic.kMovementSpeed] / 255.0f;
    }

    public Vector3 GetMovementDirection() {
        float x = mem[(int)MonadMemorySemantic.kMovementDirectionX] / 127.0f;
        float y = mem[(int)MonadMemorySemantic.kMovementDirectionY] / 127.0f;
        return new Vector3(x - 1.0f, y - 1.0f, 0.0f);
    }

    static void Inc(MonadBrain brain) {
        ++brain.mem[brain.memptr];
        ++brain.offset;
    }

    static void Dec(MonadBrain brain) {
        --brain.mem[brain.memptr];
        ++brain.offset;
    }

    static void IncPtr(MonadBrain brain) {
        ++brain.memptr;
        if (brain.memptr == brain.mem.Length) {
            brain.memptr = 0;
        }
        ++brain.offset;
    }

    static void DecPtr(MonadBrain brain) {
        if (brain.memptr > 0) {
            --brain.memptr;           
        } else {
            brain.memptr = brain.mem.Length - 1;
        }
        ++brain.offset;
    }

}
