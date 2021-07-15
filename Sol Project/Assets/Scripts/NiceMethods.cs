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
        DLL.DeleteArray(values);
        return toReturn;
    }

    static public unsafe Vector2 UnRotation(Vector2 v, float angle)
    {
        float* values = DLL.UnRotation(v.x, v.y, angle);
        Vector2 toReturn = new Vector2(*values, *(values + 1));
        DLL.DeleteArray(values);
        return toReturn;
    }

    static public Vector2 Direction(Vector2 p1, Vector2 p2)
    {
        return new Vector2(p2.x - p1.x, p2.y - p1.y).normalized;
    }

    static public float VectorAngle(Vector2 v)
    {
        return Atan2(v.y,v.x)*180/PI;
    }

    static public t DistanceSquared<t>(Vector2 p1, Vector2 p2)
    {
        var result = (p2.x - p1.x) * (p2.x - p1.x) + (p2.y - p1.y) * (p2.y - p1.y);
        return (t)Convert.ChangeType(result, typeof(t));
    }

    static public void InvertSpeed(ref Rigidbody2D r)
    {
        r.velocity = new Vector2(-r.velocity.x, -r.velocity.y);
    }

    static public void Stun(ref Rigidbody2D r)
    {
        r.velocity = new Vector2(0, 0);
    }
}
