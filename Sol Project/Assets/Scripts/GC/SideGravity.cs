using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NiceMethods;

public class SideGravity : CustomGravity
{
    public override void GravityFormula(ref Rigidbody2D rig, Vector2 position, GameObject target, GravityContext gravCTX, Orbit orbit)
    {
        if (target == null || !target.activeSelf) { Debug.LogWarning("missing object", target); return; }
        var targetPos = target.transform.position;
        if (!rig.isKinematic)
        {
            Vector2 direction = Rotation(Direction(position, targetPos), 90);
            rig.AddForce((gravCTX.isInverted ? -1 : 1) * orbit.gravityFactor * rig.mass * direction);
        }
        else Debug.Log("look here");
        rig.rotation = VectorAngle(Direction(position, targetPos)) + (gravCTX.isInverted ? 180 : 180);
    }
}
