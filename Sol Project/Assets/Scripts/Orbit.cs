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
    [SerializeField] private float gravMassSet;
    public float GravMass { get { return gravMassSet; } }

    private Rigidbody2D rig;
    private Transform transf;
    private Vector2 PosThis { get { return transf.position; } }
    public Collider2D[] InGravityField { get { return Physics2D.OverlapCircleAll(PosThis, 1f, Gravity); } }

    //list of objects this object will orbit. Needs manual set
    [SerializeField] private List<GameObject> orbits;
    [SerializeField] private LayerMask Gravity;

    public float gravityFactor;
    public float GravityFactorStart { get; private set; }
    public float gravityFactor0;

    [SerializeField] private byte gravityTypeSet;
    public byte GravityType { get; private set; }
    public byte GravityTypeStart { get { return gravityTypeSet; } }
    [SerializeField] private byte seeGravityType;

    [SerializeField] private bool doesRotateSet;
    public bool DoesRotate { get; private set; }

    [SerializeField] private bool allowGravityChangeSet;
    public bool AllowGravityChange { get; private set; }

    //used on ChangeGravityType methods and Gravity Type 2
    private LinkedList<(GameObject target, GravityContext gravityCTX)> gravityStack;
    [SerializeField] private List<GameObject> seeGravityStack;



    void Start()
    {
        GravityType = GravityTypeStart;
        AllowGravityChange = allowGravityChangeSet;

        GravityFactorStart = gravityFactor;

        gravityStack = new LinkedList<(GameObject, GravityContext)>();

        DoesRotate = doesRotateSet;

        rig = GetComponent<Rigidbody2D>();
        transf = GetComponent<Transform>();

        orbits = (List<GameObject>)TrimList(orbits);

        if (gravityFactor == 0) gravityFactor = -Physics2D.gravity.y;
        if (gravityFactor0 == 0) gravityFactor0 = 1;

        if (!rig.isKinematic) gravMassSet = rig.mass; //Einstein

        UpPosition();
    }

    void FixedUpdate()
    {
        GravitySwitch(PosThis, GravityType, gravityStack.LastOrDefault());

        if (gravityStack.Count != 0 && gravityStack.Last.Value.target == null)
        {
            gravityStack.Remove(gravityStack.Last);
            if (AllowGravityChange)
            {
                if (gravityStack.Count != 0) GravityType = gravityStack.Last.Value.gravityCTX.GravityType;
                else GravityType = GravityTypeStart;
            }
        }

        if (debug)
        {
            seeGravityType = GravityType;

            var Node = gravityStack.Last;
            for (int i = 0; i < seeGravityStack.Count; i++)
            {
                try
                {
                    seeGravityStack[i] = Node.Value.target;
                    Node = Node.Previous;
                }
                catch (NullReferenceException) { seeGravityStack[i] = null; }
            }
            while (Node is object)
            {
                seeGravityStack.Add(Node.Value.target);
                Node = Node.Previous;
            }
        }
    }

    void GravitySwitch(Vector2 pThis, byte gravityType, (GameObject target, GravityContext gravityCTX) orbit)
    {
        var target = orbit.target;
        var gravCTX = orbit.gravityCTX;
        switch (gravityType)
        {
            case 1:
                GravityFormula1(ref rig, orbits, pThis);
                UpPosition();
                break;
            case 2:
                GravityFormula2(ref rig, target, gravCTX);
                break;
            case 0:
                GravityFormula0(ref rig, orbits, pThis, gravityFactor0);
                UpPosition();
                break;
            case 3:
                GravityFormula3(ref rig, pThis, target, gravCTX);
                break;
            case 4: break;
        }
    }

    void UpPosition()
    {
        if (DoesRotate && InGravityField.Length > 0)
        {
            Transform OrbitP = InGravityField[0].GetComponent<Transform>();
            rig.rotation = VectorAngle(Direction(transf.position, OrbitP.position)) + (gravityFactor > 0 ? 90 : -90);
        }
    }

    /// <summary>
    /// Newton gravity formula. Uses both rigidbodies masses, their distance squared and a gravitational constant (defaults to 1).
    /// </summary>
    void GravityFormula0(ref Rigidbody2D selfRig, List<GameObject> targets, Vector2 selfPos, float gravFactor)
    {
        Vector2 addedForces = new Vector2(0, 0);
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] == null || !targets[i].activeSelf) { Debug.LogWarning("missing object", gameObject); continue; }
            float targetMass = 0;
            Vector2 targetPos = targets[i].transform.position;

            if (targets[i].TryGetComponent(out Orbit targetOrb)) targetMass = targetOrb.GravMass;
            else if (targets[i].TryGetComponent(out Rigidbody2D targetRig) && !targetRig.isKinematic) targetMass = targetRig.mass;

            addedForces += gravFactor * targetMass * Direction(selfPos, targetPos) / DistanceSquared(selfPos, targetPos);
        }
        if (!rig.isKinematic) selfRig.AddForce(addedForces * selfRig.mass);
        else rig.velocity += addedForces * Time.fixedDeltaTime; //addAcceleration
    }

    /// <summary>
    /// Simplified gravity formula. Add a constant acceleration if this object is within others gravity field.
    /// </summary>
    void GravityFormula1(ref Rigidbody2D selfRig, List<GameObject> targets, Vector2 selfPos, float gravFactor)
    {
        Vector2 addedForces = new Vector2(0, 0);
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] == null || !targets[i].activeSelf) { Debug.LogWarning("missing object", gameObject); continue; }
            Vector2 targetPos = targets[i].transform.position;
            Collider2D[] cols = targets[i].GetComponentsInChildren<Collider2D>(false);
            if (cols.Intersect(InGravityField).Any())
            {
                addedForces += gravFactor * selfRig.mass * Direction(selfPos, targetPos);
            }
        }
        if (!rig.isKinematic) selfRig.AddForce(addedForces);
        else Debug.Log("look here");
    }
    /// <summary>
    /// Simplified gravity formula. Add a constant acceleration if this object is within others gravity field.
    /// </summary>
    void GravityFormula1(ref Rigidbody2D rig, List<GameObject> targets, Vector2 selfPos)
    {
        GravityFormula1(ref rig, targets, selfPos, gravityFactor);
    }

    void GravityFormula2(ref Rigidbody2D rig, GameObject target, GravityContext gravCTX, float gravFactor)
    {
        if (target == null || !target.activeSelf || !(gravCTX is GravityContext2 Rule)) { Debug.LogWarning("missing object/incorrect script", gameObject); return; }

        if (!rig.isKinematic) rig.AddForce((Rule.isInverted ? -1 : 1) * rig.mass * gravFactor * Rule.direction);
        else Debug.Log("look here");
        if (DoesRotate && Rule.DoesRotate) rig.rotation = Rule.rotation + (Rule.isInverted ? 180 : 0);

    }

    void GravityFormula2(ref Rigidbody2D rig, GameObject target, GravityContext gravCTX)
    {
        GravityFormula2(ref rig, target, gravCTX, gravityFactor);
    }

    void GravityFormula3(ref Rigidbody2D selfRig, Vector2 selfPos, GameObject target, GravityContext gravCTX)
    {
        if (target == null || !target.activeSelf) { Debug.LogWarning("missing object", gameObject); return; }
        var targetPos = target.transform.position;
        if (!rig.isKinematic) selfRig.AddForce((gravCTX.isInverted ? -1 : 1) * gravityFactor * selfRig.mass * Direction(selfPos, targetPos));
        else Debug.Log("look here");
        selfRig.rotation = VectorAngle(Direction(selfPos, targetPos)) + (gravCTX.isInverted ? -90 : 90);
    }

    //prototype version 7
    public void IntoCollider(GravityContext gravCTX, GameObject intoSticky, Order order)
    {
        if (order == Order.Last) gravityStack.AddLast((intoSticky, gravCTX));
        else if (order == Order.First) gravityStack.AddFirst((intoSticky, gravCTX));

        if (AllowGravityChange) GravityType = gravityStack.Last.Value.gravityCTX.GravityType;
    }

    public void OutCollider(GameObject outSticky)
    {
        LinkedListNode<(GameObject target, GravityContext gravityCTX)> Node = gravityStack.First;
        LinkedListNode<(GameObject target, GravityContext gravityCTX)> nextNode = null;
        for (bool end = false; !end; Node = nextNode)
        {
            if (Node == gravityStack.Last)
            {
                end = true;
            }
            else nextNode = Node.Next;
            if (!Node.Value.target.activeSelf || Node.Value.target == null || Node.Value.target == outSticky) gravityStack.Remove(Node);
        }

        if (AllowGravityChange)
        {
            if (gravityStack.Count != 0) GravityType = gravityStack.Last.Value.gravityCTX.GravityType;
            else GravityType = GravityTypeStart;
        }
    }
}
