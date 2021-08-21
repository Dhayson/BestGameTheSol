using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityContext2 : GravityContext
{
    override public byte GravityType { get { return 2; } }
    [SerializeField] Vector2 startDirection;
    public Vector2 direction;
    [SerializeField] float startRotation;
    public float rotation;
    [SerializeField] Transform follow;

    new public void Start()
    {
        OnStart();
        try { var foo = follow.rotation; }
        catch(UnassignedReferenceException) { follow = null; }
    }

    public void FixedUpdate()
    {
        if(!(follow is null))
        {
            direction = NiceMethods.Rotation(startDirection, follow.rotation.eulerAngles.z);
            rotation = startRotation + follow.rotation.eulerAngles.z;
        }
    }
}
