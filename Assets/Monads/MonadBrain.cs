using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonadBrain : MonoBehaviour {

    private byte[] dna;
    private byte[] mem;

    private int memPtr;
    private int offset;

    private int memPtrMovementSpeed;
    private int memPtrMovementDirectionX;
    private int memPtrMovementDirectionY;

    private const int minMemSize = 3;
    private const int minDnaSize = 1;

    [Range(minMemSize, 1024)]
    public int maxMemSize = 1024;

    [Range(minDnaSize, 1024)]
    public int maxDnaSize = 1024;

    // Use this for initialization
    void Start () {
        mem = new byte[Random.Range(minMemSize, maxMemSize)];
        dna = new byte[Random.Range(minDnaSize, maxDnaSize)];

        memPtrMovementSpeed = Random.Range(0, mem.Length);
        memPtrMovementDirectionX = Random.Range(0, mem.Length);
        memPtrMovementDirectionY = Random.Range(0, mem.Length);

        for (int i = 0; i < dna.Length; ++i) {
            dna[i] = (byte)Random.Range(0, asm.Length);
        }
    }
    
    // Update is called once per frame
    void Update () {
        Tick();
    }

    void Tick() {
        asm[dna[offset]](this);
    }

    void IncMemVal() {
        ++mem[memPtr];
    }

    void DecMemVal() {
        --mem[memPtr];
    }

    void IncMemPtr() {
        memPtr = Common.Math.Mod(memPtr + 1, mem.Length);
    }

    void DecMemPtr() {
        memPtr = Common.Math.Mod(memPtr - 1, mem.Length);
    }

    void IncOffset() {
        offset = Common.Math.Mod(offset + 1, dna.Length);
    }

    void DecOffset() {
        offset = Common.Math.Mod(offset - 1, dna.Length);
    }

    public float GetMovementSpeed() {
        return mem[memPtrMovementSpeed] / 255.0f;
    }

    public Vector3 GetMovementDirection() {
        float x = mem[memPtrMovementDirectionX] / 127.0f;
        float y = mem[memPtrMovementDirectionY] / 127.0f;
        return new Vector3(x - 1.0f, y - 1.0f, 0.0f);
    }

    static void Nop(MonadBrain brain) {
        brain.IncOffset();
    }

    static void Inc(MonadBrain brain) {
        brain.IncMemVal();
        brain.IncOffset();
    }

    static void Dec(MonadBrain brain) {
        brain.DecMemVal();
        brain.IncOffset();
    }

    static void IncPtr(MonadBrain brain) {
        brain.IncMemPtr();
        brain.IncOffset();
    }

    static void DecPtr(MonadBrain brain) {
        brain.DecMemPtr();
        brain.IncOffset();
    }

    static Asm[] asm = {
        Nop, // 0
        Inc, // 1
        Dec, // 2
        IncPtr, // 3
        DecPtr, // 4
    };

    delegate void Asm(MonadBrain brain);

}
