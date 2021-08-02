using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NiceMethods;

public class MoveEnemy : MonoBehaviour
{
    private Rigidbody2D rig;
    private Orbit orbit;
    private Collider2D col;

    private bool jumpCD;
    public float speedx;
    public float accelerationx;
    public float decelerationx;
    public float passiveDecelerationx;
    public float jumpForce;

    public Transform jumpCheck;
    public LayerMask level;
    public LayerMask player;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        orbit = GetComponent<Orbit>();
        col = GetComponent<Collider2D>();

        if (decelerationx > 0) decelerationx *= -1;
        if (passiveDecelerationx > 0) passiveDecelerationx *= -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D[] orbitings = orbit.InGravityField;
        if(orbitings.Length == 1)
        {
            Vector2 relativeVelocity = rig.velocity - orbitings[0].GetComponentInParent<Rigidbody2D>().velocity;
            float relativeVelRotX = UnRotation(relativeVelocity, rig.rotation).x;
            if (relativeVelRotX <= speedx && speedx > 0)
            {
                rig.AddForce(Rotation(new Vector2(1, 0), rig.rotation) * accelerationx);
            }

            if (relativeVelRotX >= speedx && speedx < 0)
            {
                rig.AddForce(Rotation(new Vector2(-1, 0), rig.rotation) * accelerationx);
            }

            if(Mathf.Abs(relativeVelRotX) > Mathf.Abs(speedx))
            {
                rig.AddForce(Rotation(new Vector2(UnRotation(relativeVelocity, rig.rotation).x, 0), rig.rotation) * passiveDecelerationx);
            }
        }

        DamageOnContact(col, player, 10);
    }
}
