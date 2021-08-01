using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float Health;
    public float InvulnerableTime;
    [SerializeField] private float InvulnerableTimeCD;
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
