using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityContext2 : GravityContext
{
    override public byte GravityType { get { return 2; } }
    public Vector2 direction;
    public float rotation;
}
