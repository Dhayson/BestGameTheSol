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
    public byte gravityType;
    public float speedx;
    public float speedy;
    public bool setRotation;
    public Collider2D[] InGravityField { get; private set; }
    private int OrbitedsLenght;
    private Vector2 pThis;
    private Vector2[] pOrbits;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        transf = GetComponent<Transform>();
        rig.velocity = new Vector2(speedx, speedy);
        OrbitedsLenght = orbiteds.Length;
        pThis = GetComponent<Transform>().position;
        pOrbits = new Vector2[orbiteds.Length];
        for (int i = OrbitedsLenght - 1; i >= 0; i--)
        {
            try { pOrbits[i] = orbiteds[i].transform.position; }
            catch (UnassignedReferenceException) 
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
        InGravityField = Physics2D.OverlapCircleAll(pThis, 0.5f, Gravity);
        pThis = transf.position;
        pOrbits = new Vector2[orbiteds.Length];
        for (int i = 0; i < OrbitedsLenght; i++)
        {
            pOrbits[i] = orbiteds[i].transform.position;
            switch (gravityType)
            {
                default:
                    GravityFormula0(ref rig, orbiteds[i].GetComponent<Rigidbody2D>(), pThis, pOrbits[i]);
                    break;
                case 1:
                    GravityFormula1(ref rig, orbiteds[i], pThis, pOrbits[i]);
                    break;
            }
        }

        UpPosition();
    }

    void UpPosition()
    {
        if (setRotation && InGravityField.Length == 1)
        {
            Transform OrbitP = InGravityField[0].GetComponent<Transform>();
            rig.rotation = VectorAngle(Direction(pThis, OrbitP.position)) + 90;
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
}
