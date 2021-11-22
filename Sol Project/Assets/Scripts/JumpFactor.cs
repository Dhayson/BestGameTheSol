using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct JumpFactor
{
    public float value;

    static public JumpFactor operator *(JumpFactor jumpFactor, float num)
    {
        jumpFactor.value *= Mathf.Sqrt(num);
        return jumpFactor;
    }
    static public JumpFactor operator /(JumpFactor jumpFactor, float num)
    {
        jumpFactor.value /= Mathf.Sqrt(num);
        return jumpFactor;
    }
}
