using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float Health;
    public float InvulnerableTime;
    [SerializeField] private float InvulnerableTimeCD;
    public float speedFactor = 1;
    public float jumpFactor = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvulnerableTimeCD = InvulnerableTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0.0f)
        {
            Debug.Log("kill");
            Health = float.NaN;
        }

        if (float.IsNaN(speedFactor))
        {
            speedFactor = 1f;
        }
        if (float.IsNaN(jumpFactor))
        {
            jumpFactor = 1f;
        }
    }

    public void FixedUpdate()
    {
        if (InvulnerableTimeCD > 0) InvulnerableTimeCD -= Time.fixedDeltaTime;
    }

    public void Damage(int damage)
    {
        if (InvulnerableTimeCD <= 0)
        {
            Health -= damage;
            InvulnerableTimeCD = InvulnerableTime;
        }
    }
}
