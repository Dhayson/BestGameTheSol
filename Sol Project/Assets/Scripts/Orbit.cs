using System;
using System.Collections;
using System.Collections.Generic;
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

        UpPosition();
        if (gravityFactor == 0) gravityFactor = -Physics2D.gravity.y;
    }

    void FixedUpdate()
    {
        pThis = transf.position;
        pOrbits = new Vector2[orbiteds.Length];
        for (int i = 0; i < OrbitedsLenght; i++)
        {
            pOrbits[i] = orbiteds[i].transform.position;
            switch (gravityType)
            {
                default:
                    rig.AddForce(rig.mass * orbiteds[i].GetComponent<Rigidbody2D>().mass * Direction(pThis, pOrbits[i]) 
                        / DistanceSquared<float>(pThis, pOrbits[i]));
                    break;
                case 1:
                    rig.AddForce(gravityFactor * rig.mass * Direction(pThis, pOrbits[i]));
                    break;
            }
        }

        UpPosition();
    }

    void UpPosition()
    {
        InGravityField = Physics2D.OverlapCircleAll(pThis, 0.5f, Gravity);
        if (setRotation && InGravityField.Length == 1)
        {
            Transform OrbitP = InGravityField[0].GetComponent<Transform>();
            rig.rotation = VectorAngle(Direction(pThis, OrbitP.position)) + 90;
        }
    }
}
