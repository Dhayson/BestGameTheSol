using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using static NiceMethods;

[RequireComponent(typeof(Rigidbody2D))]
public class Orbit : MonoBehaviour
{
    private Rigidbody2D rig;
    private Transform transf;

    [SerializeField] private List<GameObject> orbits;
    [SerializeField] private LayerMask Gravity;
    [SerializeField] private float gravityFactor;

    public byte GravityType { get; private set; }
    public byte GravityTypeStart { get; private set; }
    [SerializeField] private byte gravityTypeSet, seeGravityType;

    public bool setRotation;

    public Collider2D[] InGravityField { get; private set; }

    private int OrbitedsLenght;
    private Vector2[] pOrbits;

    [SerializeField] private bool allowGravityChangeSet;
    public bool AllowGravityChange {get; private set;}

    void Start()
    {
        GravityType = gravityTypeSet;
        GravityTypeStart = GravityType;
        AllowGravityChange = allowGravityChangeSet;

        rig = GetComponent<Rigidbody2D>();
        transf = GetComponent<Transform>();
        Vector2 pThis = transf.position;

        TrimList(ref orbits);

        if (gravityFactor == 0) gravityFactor = -Physics2D.gravity.y;

        InGravityField = Physics2D.OverlapCircleAll(pThis, 0.5f, Gravity);

        UpPosition();
    }

    void FixedUpdate()
    {
        OrbitedsLenght = orbits.Count;
        Vector2 pThis = transf.position;
        InGravityField = Physics2D.OverlapCircleAll(pThis, 0.5f, Gravity);
        pOrbits = new Vector2[orbits.Count];
        for (int i = 0; i < OrbitedsLenght; i++)
        {
            pOrbits[i] = orbits[i].transform.position;
            switch (GravityType)
            {
                default:
                    GravityFormula0(ref rig, orbits[i].GetComponent<Rigidbody2D>(), pThis, pOrbits[i]);
                    UpPosition();
                    break;
                case 1:
                    GravityFormula1(ref rig, orbits[i], pThis, pOrbits[i]);
                    UpPosition();
                    break;
                case 2:
                    if(GravityFormula2(ref rig, orbits[i])) i = 131072; //just a very high int to break out the loop
                    break;
            }
        }

        seeGravityType = GravityType;
    }

    void UpPosition()
    {
        if (setRotation && InGravityField.Length == 1)
        {
            Transform OrbitP = InGravityField[0].GetComponent<Transform>();
            rig.rotation = VectorAngle(Direction(transf.position, OrbitP.position)) + 90;
        }
    }

    /// <summary>
    /// Newton gravity formula. Uses both rigidbodies masses, their distance squared and a gravitational constant (defaults to 1).
    /// </summary>
    void GravityFormula0(ref Rigidbody2D selfRig, Rigidbody2D targetRig, Vector2 selfPos, Vector2 targetPos, float gravFactor = 1)
    {
        selfRig.AddForce(gravFactor * selfRig.mass * targetRig.mass * Direction(selfPos, targetPos) / DistanceSquared<float>(selfPos, targetPos));
    }

    /// <summary>
    /// Simplified gravity formula. Add a constant acceleration if this object is within others gravity field.
    /// </summary>
    void GravityFormula1(ref Rigidbody2D selfRig, GameObject target, Vector2 selfPos, Vector2 targetPos, float gravFactor)
    {
        Collider2D[] cols = target.GetComponentsInChildren<Collider2D>(false);
        if (cols.Intersect(InGravityField).Any())
        {
            selfRig.AddForce(gravFactor * selfRig.mass * Direction(selfPos, targetPos));
        }
    }
    /// <summary>
    /// Simplified gravity formula. Add a constant acceleration if this object is within others gravity field.
    /// </summary>
    void GravityFormula1(ref Rigidbody2D rig, GameObject target, Vector2 selfPos, Vector2 targetPos)
    {
        GravityFormula1(ref rig, target, selfPos, targetPos, gravityFactor);
    }

    bool GravityFormula2(ref Rigidbody2D rig, GameObject target, float gravFactor)
    {
        Collider2D[] cols = target.GetComponentsInChildren<Collider2D>(false);
        if (cols.Intersect(InGravityField).Any() && target.TryGetComponentInChildren(out ChangeGravityType Rule))
        {
            rig.AddForce(gravFactor * Rule.direction);
            if(setRotation) rig.rotation = Rule.rotation;
            return true;
        }
        return false;
    }

    bool GravityFormula2(ref Rigidbody2D rig, GameObject target)
    {
        return GravityFormula2(ref rig, target, gravityFactor);
    }

    //prototype version 2
    public void IntoCollider(byte gravType)
    {
        if (AllowGravityChange) GravityType = gravType;
    }

    public void OutCollider()
    {
        foreach (Collider2D g in InGravityField)
        {
            if (g.gameObject.TryGetComponent<ChangeGravityType>(out _)) return;
        }
        //reset to default if there aren't any modifiers
        GravityType = GravityTypeStart;
    }
}
