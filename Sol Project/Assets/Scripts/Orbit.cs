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
    public Collider2D[] Orbitings { get; private set; }

    private int Orbitados;
    private Vector2 p1;
    private Vector2[] ps;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = new Vector2(speedx, speedy);
        Orbitados = orbiteds.Length;
        p1 = GetComponent<Transform>().position;
        ps = new Vector2[orbiteds.Length];
        for (int i = Orbitados - 1; i >= 0; i--)
        {
            try { ps[i] = orbiteds[i].transform.position; }
            catch (UnassignedReferenceException) 
            {
                for (int j = i; j < Orbitados - 1; j++)
                {
                    ps[j] = ps[j + 1];
                    orbiteds[j] = orbiteds[j + 1];
                }
                Orbitados--;
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
        p1 = GetComponent<Transform>().position;
        ps = new Vector2[orbiteds.Length];
        for (int i = 0; i < Orbitados; i++)
        {
            ps[i] = orbiteds[i].transform.position;
            rig.AddForce(rig.mass * orbiteds[i].GetComponent<Rigidbody2D>().mass * Direction(p1, ps[i]) /
                DistanceSquared<float>(p1, ps[i]));
        }

        Orbitings = Physics2D.OverlapCircleAll(GetComponent<Transform>().position, 0.5f, Gravity);
        if (setRotation && Orbitings.Length == 1)
        {
            Orbitings[0].TryGetComponent(out Transform OrbitP);
            rig.rotation = VectorAngle(Direction(p1, OrbitP.position)) + 90;
        }
    }

    
}
