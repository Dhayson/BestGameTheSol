using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static NiceMethods;

public class Orbit : MonoBehaviour
{
    private Rigidbody2D rig;

    [SerializeField] private GameObject[] orbiteds;
    [SerializeField] private LayerMask Gravity;
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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) InvertSpeed(ref rig);
        if (Input.GetKey(KeyCode.E)) Stun(ref rig);
    }

    void FixedUpdate()
    {
        pThis = GetComponent<Transform>().position;
        pOrbits = new Vector2[orbiteds.Length];
        for (int i = 0; i < OrbitedsLenght; i++)
        {
            pOrbits[i] = orbiteds[i].transform.position;
            rig.AddForce(rig.mass * orbiteds[i].GetComponent<Rigidbody2D>().mass * Direction(pThis, pOrbits[i]) / DistanceSquared<float>(pThis, pOrbits[i]));
        }

        InGravityField = Physics2D.OverlapCircleAll(pThis, 0.5f, Gravity);
        if (setRotation && InGravityField.Length == 1)
        {
            InGravityField[0].TryGetComponent(out Transform OrbitP);
            rig.rotation = VectorAngle(Direction(pThis, OrbitP.position)) + 90;
        }
    }
}
