using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigInformation : MonoBehaviour
{
    Rigidbody2D rig;
    Orbit orb;
    bool hasOrbit;
    [SerializeField] private float velocityModule;
    [SerializeField] private float relativeVelocityModule;
    private Vector2 relativeVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        hasOrbit = TryGetComponent(out orb);
    }

    // Update is called once per frame
    void Update()
    {
        velocityModule = rig.velocity.magnitude;
        if (hasOrbit)
        {
            if (orb.InGravityField.Length == 1) relativeVelocity = rig.velocity - orb.InGravityField[0].GetComponentInParent<Rigidbody2D>().velocity;
            relativeVelocityModule = relativeVelocity.magnitude;
        }
    }
}
