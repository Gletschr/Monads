using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonadBrain : MonoBehaviour {

    byte[] dna;
    byte[] mem;

    long memptr = 0;
    long offset = 0;

    enum MemorySemantic {
        kMovementDirectionX = 0,
        kMovementDirectionY = 1,
        kMovementSpeed = 2,
    }

    // Use this for initialization
    void Start () {
        mem = new byte[3];
        dna = new byte[Random.Range(10, 1024)];
        for (int i = 0; i < dna.Length; ++ i) {
            dna[i] = (byte)Random.Range(0, asm.Length);
        }
    }
    
    // Update is called once per frame
    void Update () {
        Tick();
        UpdateOffset();

    }

    void Tick() {
        asm[dna[offset]](this);
    }

    void UpdateOffset() {
        if (offset >= dna.Length) {
            offset = offset - dna.Length;
        }
    }
 
    public float GetMovementSpeed() {
        return mem[(int)MemorySemantic.kMovementSpeed] / 255.0f;
    }

    public Vector3 GetMovementDirection() {
        float x = mem[(int)MemorySemantic.kMovementDirectionX] / 127.0f;
        float y = mem[(int)MemorySemantic.kMovementDirectionY] / 127.0f;
        return new Vector3(x - 1.0f, y - 1.0f, 0.0f);
    }

    static void Nop(MonadBrain brain) {
        ++brain.offset;
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

    static void GoTo(MonadBrain brain) {
        brain.offset += brain.mem[brain.memptr];
    }

    static void JmpIf(MonadBrain brain) {
        ++brain.offset;
        if (brain.mem[brain.memptr] > 0) {
            brain.UpdateOffset();
            brain.offset += brain.dna[brain.offset];
        }
    }

    static Asm[] asm = {
        Nop, // 0
        Inc, // 1
        Dec, // 2
        IncPtr, // 3
        DecPtr, // 4
        GoTo, // 5
        JmpIf, // 6
        Nop, // 6
        Nop, // 7
        Nop, // 8
        Nop, // 9
        Nop, // 10
        Nop, // 11
        Nop, // 12
        Nop, // 13
        Nop, // 14
        Nop, // 15
        Nop, // 16
        Nop, // 17
        Nop, // 18
        Nop, // 19
        Nop, // 20
        Nop, // 21
        Nop, // 22
        Nop, // 23
        Nop, // 24
        Nop, // 25
        Nop, // 26
        Nop, // 27
        Nop, // 28
        Nop, // 29
        Nop, // 30
        Nop, // 31
        Nop, // 32
        Nop, // 33
        Nop, // 34
        Nop, // 35
        Nop, // 36
        Nop, // 37
        Nop, // 38
        Nop, // 39
        Nop, // 40
        Nop, // 41
        Nop, // 42
        Nop, // 43
        Nop, // 44
        Nop, // 45
        Nop, // 46
        Nop, // 47
        Nop, // 48
        Nop, // 49
        Nop, // 50
        Nop, // 51
        Nop, // 52
        Nop, // 53
        Nop, // 54
        Nop, // 55
        Nop, // 56
        Nop, // 57
        Nop, // 58
        Nop, // 59
        Nop, // 60
        Nop, // 61
        Nop, // 62
        Nop, // 63
        Nop, // 64
        Nop, // 65
        Nop, // 66
        Nop, // 67
        Nop, // 68
        Nop, // 69
        Nop, // 70
        Nop, // 71
        Nop, // 72
        Nop, // 73
        Nop, // 74
        Nop, // 75
        Nop, // 76
        Nop, // 77
        Nop, // 78
        Nop, // 79
        Nop, // 80
        Nop, // 81
        Nop, // 82
        Nop, // 83
        Nop, // 84
        Nop, // 85
        Nop, // 86
        Nop, // 87
        Nop, // 88
        Nop, // 89
        Nop, // 90
        Nop, // 91
        Nop, // 92
        Nop, // 93
        Nop, // 94
        Nop, // 95
        Nop, // 96
        Nop, // 97
        Nop, // 98
        Nop, // 99
        Nop, // 100
        Nop, // 101
        Nop, // 102
        Nop, // 103
        Nop, // 104
        Nop, // 105
        Nop, // 106
        Nop, // 107
        Nop, // 108
        Nop, // 109
        Nop, // 110
        Nop, // 111
        Nop, // 112
        Nop, // 113
        Nop, // 114
        Nop, // 115
        Nop, // 116
        Nop, // 117
        Nop, // 118
        Nop, // 119
        Nop, // 120
        Nop, // 121
        Nop, // 122
        Nop, // 123
        Nop, // 124
        Nop, // 125
        Nop, // 126
        Nop, // 127
        Nop, // 128
        Nop, // 129
        Nop, // 130
        Nop, // 131
        Nop, // 132
        Nop, // 133
        Nop, // 134
        Nop, // 135
        Nop, // 136
        Nop, // 137
        Nop, // 138
        Nop, // 139
        Nop, // 140
        Nop, // 141
        Nop, // 142
        Nop, // 143
        Nop, // 144
        Nop, // 145
        Nop, // 146
        Nop, // 147
        Nop, // 148
        Nop, // 149
        Nop, // 150
        Nop, // 151
        Nop, // 152
        Nop, // 153
        Nop, // 154
        Nop, // 155
        Nop, // 156
        Nop, // 157
        Nop, // 158
        Nop, // 159
        Nop, // 160
        Nop, // 161
        Nop, // 162
        Nop, // 163
        Nop, // 164
        Nop, // 165
        Nop, // 166
        Nop, // 167
        Nop, // 168
        Nop, // 169
        Nop, // 170
        Nop, // 171
        Nop, // 172
        Nop, // 173
        Nop, // 174
        Nop, // 175
        Nop, // 176
        Nop, // 177
        Nop, // 178
        Nop, // 179
        Nop, // 180
        Nop, // 181
        Nop, // 182
        Nop, // 183
        Nop, // 184
        Nop, // 185
        Nop, // 186
        Nop, // 187
        Nop, // 188
        Nop, // 189
        Nop, // 190
        Nop, // 191
        Nop, // 192
        Nop, // 193
        Nop, // 194
        Nop, // 195
        Nop, // 196
        Nop, // 197
        Nop, // 198
        Nop, // 199
        Nop, // 200
        Nop, // 201
        Nop, // 202
        Nop, // 203
        Nop, // 204
        Nop, // 205
        Nop, // 206
        Nop, // 207
        Nop, // 208
        Nop, // 209
        Nop, // 210
        Nop, // 211
        Nop, // 212
        Nop, // 213
        Nop, // 214
        Nop, // 215
        Nop, // 216
        Nop, // 217
        Nop, // 218
        Nop, // 219
        Nop, // 220
        Nop, // 221
        Nop, // 222
        Nop, // 223
        Nop, // 224
        Nop, // 225
        Nop, // 226
        Nop, // 227
        Nop, // 228
        Nop, // 229
        Nop, // 230
        Nop, // 231
        Nop, // 232
        Nop, // 233
        Nop, // 234
        Nop, // 235
        Nop, // 236
        Nop, // 237
        Nop, // 238
        Nop, // 239
        Nop, // 240
        Nop, // 241
        Nop, // 242
        Nop, // 243
        Nop, // 244
        Nop, // 245
        Nop, // 246
        Nop, // 247
        Nop, // 248
        Nop, // 249
        Nop, // 250
        Nop, // 251
        Nop, // 252
        Nop, // 253
        Nop, // 254
        Nop, // 255
    };

    delegate void Asm(MonadBrain brain);

}
