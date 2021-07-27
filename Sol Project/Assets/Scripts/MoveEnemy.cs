using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private Rigidbody2D rig;
    private Orbit orbit;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        orbit = GetComponent<Orbit>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
