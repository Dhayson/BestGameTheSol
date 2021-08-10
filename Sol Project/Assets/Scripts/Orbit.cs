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

    //list of objects this object will orbit. Needs manual set
    [SerializeField] private List<GameObject> orbits;

    //used on ChangeGravityType methods and Gravity Type 2
    private LinkedList<(GameObject,byte)> gravityStack;
    [SerializeField] private GameObject[] seeGravityStack;

    [SerializeField] private LayerMask Gravity;

    [SerializeField] private float gravityFactor;

    [SerializeField] private byte gravityTypeSet;
    public byte GravityType { get; private set; }
    public byte GravityTypeStart { get; private set; }
    [SerializeField] private byte seeGravityType;

    [SerializeField] private bool doesRotateSet;
    public bool DoesRotate { get; private set; }

    public Collider2D[] InGravityField { get; private set; }

    private int OrbitedsLenght;

    [SerializeField] private bool allowGravityChangeSet;
    public bool AllowGravityChange { get; private set; }

    void Start()
    {
        GravityType = gravityTypeSet;
        GravityTypeStart = GravityType;
        AllowGravityChange = allowGravityChangeSet;

        gravityStack = new LinkedList<(GameObject,byte)>();
        gravityStack.DefaultIfEmpty((null, GravityTypeStart));

        DoesRotate = doesRotateSet;

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
        InGravityField = Physics2D.OverlapCircleAll(pThis, 1f, Gravity);

        GravitySwitch(pThis, GravityType);

        seeGravityType = GravityType;

        var Node = gravityStack.Last;
        for (int i = 0; i < seeGravityStack.Length; i++)
        {
            try 
            {
                seeGravityStack[i] = Node.Value.Item1;
                Node = Node.Previous;
            }
            catch (NullReferenceException) { seeGravityStack[i] = null; }
        }
    }

    void GravitySwitch(Vector2 pThis, byte gravityType)
    {
        switch (gravityType)
        {
            case 1:
                GravityFormula1(ref rig, orbits, pThis);
                UpPosition();
                break;
            case 2:
                GravityFormula2(ref rig, gravityStack.LastOrDefault().Item1);
                break;
            case 0:
                for (int i = 0; i < OrbitedsLenght; i++)
                {
                    Vector2 pOrbit = orbits[i].transform.position;
                    GravityFormula0(ref rig, orbits[i].GetComponent<Rigidbody2D>(), pThis, pOrbit);
                }
                UpPosition();
                break;
        }
    }

    void UpPosition()
    {
        if (DoesRotate && InGravityField.Length == 1)
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
    void GravityFormula1(ref Rigidbody2D selfRig, List<GameObject> targets, Vector2 selfPos, float gravFactor)
    {
        Vector2 addedForces = new Vector2(0, 0);
        for (int i = 0; i < targets.Count; i++)
        {
            Vector2 targetPos = targets[i].transform.position;
            Collider2D[] cols = targets[i].GetComponentsInChildren<Collider2D>(false);
            if (cols.Intersect(InGravityField).Any())
            {
                addedForces += gravFactor * selfRig.mass * Direction(selfPos, targetPos);
            }
        }
        selfRig.AddForce(addedForces);
    }
    /// <summary>
    /// Simplified gravity formula. Add a constant acceleration if this object is within others gravity field.
    /// </summary>
    void GravityFormula1(ref Rigidbody2D rig, List<GameObject> targets, Vector2 selfPos)
    {
        GravityFormula1(ref rig, targets, selfPos, gravityFactor);
    }

    void GravityFormula2(ref Rigidbody2D rig, GameObject target, float gravFactor)
    {
        if (target is null) return;
        Collider2D[] cols = target.GetComponentsInChildren<Collider2D>(false);
        if (cols.Intersect(InGravityField).Any() && target.TryGetComponentInChildren(out ChangeGravityType2 Rule))
        {
            rig.AddForce(gravFactor * Rule.direction);
            if (DoesRotate) rig.rotation = Rule.rotation;
        }
    }

    void GravityFormula2(ref Rigidbody2D rig, GameObject target)
    {
        GravityFormula2(ref rig, target, gravityFactor);
    }

    //prototype version 6
    public void IntoCollider(byte gravType, GameObject intoSticky)
    {
        if (AllowGravityChange) GravityType = gravType;
        gravityStack.AddLast((intoSticky, gravType));
    }

    public void OutCollider(byte gravType, GameObject outSticky)
    {
        for (var Node = gravityStack.First; !(Node is null); Node = Node.Next)
        {
            if (Node.Value.Item1 == outSticky) gravityStack.Remove(Node);
        }

        if (AllowGravityChange)
        {
            if (gravityStack.Count != 0) GravityType = gravityStack.Last().Item2;
            else GravityType = GravityTypeStart;
        }
    }
}
