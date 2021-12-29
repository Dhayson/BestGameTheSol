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
    [SerializeField] private Transform follow;
    public bool DoesRotate = true;

    new public void Start()
    {
        base.Start();
        try { var foo = follow.rotation; }
        catch (UnassignedReferenceException) { follow = null; }
        StartDirection = direction;
        StartRotation = rotation;
    }

    public void FixedUpdate()
    {
        //this only matters if the parent object moves or rotates.
        if (!(follow is null))
        {
            direction = NiceMethods.Rotation(StartDirection, follow.rotation.eulerAngles.z);
            rotation = StartRotation + follow.rotation.eulerAngles.z;
        }
    }
}
