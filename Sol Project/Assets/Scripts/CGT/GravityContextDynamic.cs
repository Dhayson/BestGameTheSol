using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityContextDynamic : GravityContext
{
    [SerializeField] private byte gravityTypeSet;
    public override byte GravityType { get { return gravityTypeSet; } }
}
