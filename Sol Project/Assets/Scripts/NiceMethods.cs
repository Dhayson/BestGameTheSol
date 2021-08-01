using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static UnityEngine.Mathf;

static public class NiceMethods
{
    static public unsafe Vector2 Rotation(Vector2 v, float angle)
    {
        float* values = DLL.Rotation(v.x, v.y, angle);
        Vector2 toReturn =  new Vector2(*values, *(values + 1));
        DLL.DeleteArrayF(ref values);
        return toReturn;
    }

    static public unsafe Vector2 UnRotation(Vector2 v, float angle)
    {
        float* values = DLL.UnRotation(v.x, v.y, angle);
        Vector2 toReturn = new Vector2(*values, *(values + 1));
        DLL.DeleteArrayF(ref values);
        return toReturn;
    }

    /// <summary>
    /// Returns the Vector2 that represents the direction between two points in 2D space
    /// 
    /// The difference between two Vector2, normalized
    /// </summary>
    static public Vector2 Direction(Vector2 p1, Vector2 p2)
    {
        return (p2 - p1).normalized;
    }

    /// <summary>
    /// Returns the antitangent of a Vector2 in degrees
    /// </summary>
    static public float VectorAngle(Vector2 v)
    {
        return Atan2(v.y,v.x)*180/PI;
    }

    static public type DistanceSquared<type>(Vector2 p1, Vector2 p2) where type : struct
    {
        float result = (p2.x - p1.x) * (p2.x - p1.x) + (p2.y - p1.y) * (p2.y - p1.y);
        return (type)Convert.ChangeType(result, typeof(type));
    }

    static public void InvertSpeed(ref Rigidbody2D r)
    {
        r.velocity = new Vector2(-r.velocity.x, -r.velocity.y);
    }

    static public void Stun(ref Rigidbody2D r)
    {
        r.velocity = new Vector2(0, 0);
    }

    /// <summary>
    /// Check if a Layer is contained in a LayerMask
    /// </summary>
    static public bool CompareLayer(int layer, LayerMask layermask)
    {
        //https://answers.unity.com/questions/50279/check-if-layer-is-in-layermask.html
        return layermask == (layermask | (1 << layer));
    }
}
