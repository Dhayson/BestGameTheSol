using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityContext2 : GravityContext
{
    override public byte GravityType { get { return 2; } }
    public Vector2 StartDirection { get; private set; }
    public Vector2 BaseDirection { get; set; }
    public Vector2 direction;

    public float StartRotation { get; private set; }
    public float BaseRotation { get; set; }
    public float rotation;
    public bool DoesRotateTarget = true;
    [SerializeField] private bool DoesRotateSelf = true;

    new public void Start()
    {
        base.Start();
        BaseDirection = StartDirection = direction;
        BaseRotation = StartRotation = rotation;
        direction = NiceMethods.Rotation(BaseDirection, target.transform.rotation.eulerAngles.z);
        rotation = BaseRotation + target.transform.rotation.eulerAngles.z;
    }

    public void FixedUpdate()
    {
        //this only matters if the object rotates.
        if (DoesRotateSelf)
        {
            direction = NiceMethods.Rotation(BaseDirection, target.transform.rotation.eulerAngles.z);
            rotation = BaseRotation + target.transform.rotation.eulerAngles.z;
        }
    }
}
