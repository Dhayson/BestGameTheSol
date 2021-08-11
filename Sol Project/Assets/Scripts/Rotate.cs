using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rotate : MonoBehaviour
{
    private Rigidbody2D rig;
    public float angularVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rig.angularVelocity = angularVelocity;
    }
}
