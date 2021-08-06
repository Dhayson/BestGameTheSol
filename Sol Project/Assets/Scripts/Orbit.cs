using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using static NiceMethods;

public class Orbit : MonoBehaviour
{
    private Rigidbody2D rig;
    private Transform transf;

    [SerializeField] private GameObject[] orbiteds;
    [SerializeField] private LayerMask Gravity;
    [SerializeField] private float gravityFactor;

    public byte GravityType { get; private set; }
    public byte GravityTypeStart { get; private set; }
    [SerializeField] private byte gravityTypeSet, seeGravityType;

    public float speedx;
    public float speedy;
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

        rig.velocity = new Vector2(speedx, speedy);

        OrbitedsLenght = orbiteds.Length;
        Vector2 pThis = transf.position;
        pOrbits = new Vector2[orbiteds.Length];
        for (int i = OrbitedsLenght - 1; i >= 0; i--)
        {
            try { pOrbits[i] = orbiteds[i].transform.position; }
            catch (Exception e) when (e is UnassignedReferenceException || e is NullReferenceException)
            {
                for (int j = i; j < OrbitedsLenght - 1; j++)
                {
                    pOrbits[j] = pOrbits[j + 1];
                    orbiteds[j] = orbiteds[j + 1];
                }
                OrbitedsLenght--;
            }
        }

        if (gravityFactor == 0) gravityFactor = -Physics2D.gravity.y;

        InGravityField = Physics2D.OverlapCircleAll(pThis, 0.5f, Gravity);

        UpPosition();
    }

    void FixedUpdate()
    {
        Vector2 pThis = transf.position;
        InGravityField = Physics2D.OverlapCircleAll(pThis, 0.5f, Gravity);
        pOrbits = new Vector2[orbiteds.Length];
        for (int i = 0; i < OrbitedsLenght; i++)
        {
            pOrbits[i] = orbiteds[i].transform.position;
            switch (GravityType)
            {
                default:
                    GravityFormula0(ref rig, orbiteds[i].GetComponent<Rigidbody2D>(), pThis, pOrbits[i]);
                    UpPosition();
                    break;
                case 1:
                    GravityFormula1(ref rig, orbiteds[i], pThis, pOrbits[i]);
                    UpPosition();
                    break;
                case 2:
                    if(GravityFormula2(ref rig, orbiteds[i])) i = 131072; //just a very high int to break out the loop
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
    void GravityFormula0(ref Rigidbody2D rig, Rigidbody2D target, Vector2 selfPos, Vector2 targetPos, float gravFactor = 1)
    {
        rig.AddForce(gravFactor * rig.mass * target.mass * Direction(selfPos, targetPos) / DistanceSquared<float>(selfPos, targetPos));
    }

    /// <summary>
    /// Simplified gravity formula. Add a constant acceleration if this object is within others gravity field.
    /// </summary>
    void GravityFormula1(ref Rigidbody2D rig, GameObject target, Vector2 selfPos, Vector2 targetPos, float gravFactor)
    {
        Collider2D[] cols = target.GetComponentsInChildren<Collider2D>(false);
        if (cols.Intersect(InGravityField).Any())
        {
            rig.AddForce(gravFactor * rig.mass * Direction(selfPos, targetPos));
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
            rig.rotation = Rule.rotation;
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
