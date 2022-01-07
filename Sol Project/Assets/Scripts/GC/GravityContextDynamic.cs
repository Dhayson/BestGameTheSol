using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityContextDynamic : GravityContext
{
    [SerializeField] private byte gravityTypeSet;
    [SerializeField] private CustomGravity customGravity;
    public override byte GravityType { get { return gravityTypeSet; } }

    public override void GravityFormula(ref Rigidbody2D rig, Vector2 position, GameObject target, Orbit orbit)
    {
        //if GravityType is 5
        customGravity.GravityFormula(ref rig, position, target, this, orbit);
    }

    new public void Start()
    {
        base.Start();
        if (gravityTypeSet == 2)
        {
            enabled = false;
            Debug.LogWarning("invalid gravity type");
        }
    }
}
