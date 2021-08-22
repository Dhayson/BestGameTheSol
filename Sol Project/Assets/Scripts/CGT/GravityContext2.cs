using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityContext2 : GravityContext
{
    override public byte GravityType { get { return 2; } }
    public Vector2 StartDirection { get; private set; }
    public Vector2 direction;
    public float StartRotation { get; private set; }
    public float rotation;
    [SerializeField] Transform follow;
    public bool DoesRotate = true;

    new public void Start()
    {
        OnStart();
        try { var foo = follow.rotation; }
        catch(UnassignedReferenceException) { follow = null; }
        StartDirection = direction;
        StartRotation = rotation;
    }

    public void FixedUpdate()
    {
        if(!(follow is null))
        {
            direction = NiceMethods.Rotation(StartDirection, follow.rotation.eulerAngles.z);
            rotation = StartRotation + follow.rotation.eulerAngles.z;
        }
    }
}
