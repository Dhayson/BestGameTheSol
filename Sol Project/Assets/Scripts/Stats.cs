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
    [SerializeField] public JumpFactor jumpFactor;

    // Start is called before the first frame update
    void Start()
    {
        InvulnerableTimeCD = InvulnerableTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0.0f)
        {
            Kill();
            Health = float.NaN;
        }

        if (float.IsNaN(speedFactor))
        {
            speedFactor = 1f;
        }
        if (float.IsNaN(jumpFactor.value))
        {
            jumpFactor.value = 1f;
        }
    }

    public void FixedUpdate()
    {
        if (InvulnerableTimeCD > 0) InvulnerableTimeCD -= Time.fixedDeltaTime;
        SpaceDrift();
    }

    public void Damage(int damage)
    {
        if (InvulnerableTimeCD <= 0)
        {
            Health -= damage;
            InvulnerableTimeCD = InvulnerableTime;
        }
    }
    public bool IsSpaceDrifting = false;
    [SerializeField] private float spaceDriftMaxTime = 4;
    private float spaceDriftTime;

    public void SpaceDrift()
    {
        if (IsSpaceDrifting)
        {
            spaceDriftTime += Time.fixedDeltaTime;
        }
        else
        {
            spaceDriftTime = 0;
        }

        if (spaceDriftTime >= spaceDriftMaxTime)
        {
            Kill();
            spaceDriftTime = float.NaN;
        }
    }

    public void Kill()
    {
        Debug.Log($"kill {gameObject}");
        //uncomment to inactivate objects when they die.
        //gameObject.SetActive(false);
    }
}
