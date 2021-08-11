using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigInformation : MonoBehaviour
{
    Rigidbody2D rig;
    Transform transf;
    Orbit orb;
    bool hasOrbit;
    [SerializeField] private float velocityModule;
    [SerializeField] private float relativeVelocityModule;
    [SerializeField] private float relativeVelocityRotation;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        transf = GetComponent<Transform>();
        hasOrbit = TryGetComponent(out orb);
    }

    // Update is called once per frame
    void Update()
    {
        if (NiceMethods.debug)
        {
            velocityModule = rig.velocity.magnitude;
            if (hasOrbit)
            {
                if (orb.InGravityField.Length == 1)
                {
                    Rigidbody2D target = orb.InGravityField[0].GetComponentInParent<Rigidbody2D>();
                    Vector2 relativeVelocity = rig.velocity - target.velocity;
                    relativeVelocityModule = relativeVelocity.magnitude;
                    Vector2 relativeVelocityRotationV = relativeVelocity - target.angularVelocity.ToLinearVelocity(transf.position, target.position);
                    relativeVelocityRotation = relativeVelocityRotationV.magnitude;
                }
            }
        }
    }
}
