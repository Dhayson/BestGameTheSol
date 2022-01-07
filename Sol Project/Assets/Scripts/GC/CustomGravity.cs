using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public abstract class CustomGravity : MonoBehaviour
{
    public abstract void GravityFormula(ref Rigidbody2D rig, Vector2 position, GameObject target, GravityContext gravCTX, Orbit orbit);
}
