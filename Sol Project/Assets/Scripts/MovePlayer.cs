using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Physics2D;
using static NiceMethods;

public class MovePlayer : MonoBehaviour
{
    public Sprite flying;
    public Sprite normal;

    private bool jumpCD;
    [SerializeField] private float speedx;
    [SerializeField] private float accelerationx;
    [SerializeField] private float decelerationx;
    [SerializeField] private float passiveDecelerationx;
    public float jumpForce;
    [SerializeField] private bool followRotation;

    [SerializeField] private Transform jumpCheck;
    [SerializeField] private LayerMask level;

    enum Directions { right, left, stop, vertical, clock };
    private int[] buttons;

    private Rigidbody2D rig;
    private Transform transf;
    private Orbit orbit;
    private SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        transf = GetComponent<Transform>();
        orbit = GetComponent<Orbit>();
        render = GetComponent<SpriteRenderer>();
        buttons = new int[Enum.GetValues(typeof(Directions)).Length];

        if (decelerationx > 0) decelerationx *= -1;
        if (passiveDecelerationx > 0) passiveDecelerationx *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        buttons[(int)Directions.right] = Input.GetKey(KeyCode.D) ? 1 : 0;
        buttons[(int)Directions.left] = Input.GetKey(KeyCode.A) ? -1 : 0;
        buttons[(int)Directions.stop] = buttons[(int)Directions.right] + buttons[(int)Directions.left];

        buttons[(int)Directions.clock] = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) - (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0);

        if (Input.GetKeyDown(KeyCode.Space) && OverlapCircle(jumpCheck.position, 0.1f, level) && jumpCD)
        {
            rig.AddRelativeForce(new Vector2 (0, jumpForce));
            jumpCD = false; count = 0;
        }

        if (Input.GetKeyDown(KeyCode.E)) LogGravity();
    }

    [NonSerialized] public byte count = 0;
    void FixedUpdate()
    {
        Collider2D[] orbitings = orbit.InGravityField;
        if ((orbitings.Length == 1 || (orbit.GravityType == 2 || orbit.GravityType == 3) && orbitings.Length > 0) && orbit.GravityType != 4)
        {
            Rigidbody2D rigTarget = orbitings[0].GetComponentInParent<Rigidbody2D>();
            Vector2 rotationVelocity = followRotation ? rigTarget.angularVelocity.ToLinearVelocity(transf.position, rigTarget.position) : Vector2.zero;
            Vector2 relativeVelocity = rig.velocity - rigTarget.velocity - rotationVelocity;
            float relativeVelRotX = UnRotation(relativeVelocity, rig.rotation).x;
            if (buttons[(int)Directions.stop] == 0)
            {
                rig.AddForce(Rotation(new Vector2(UnRotation(relativeVelocity, rig.rotation).x, 0), rig.rotation) * decelerationx);
            }
            else
            {
                if (relativeVelRotX <= speedx)
                {
                    rig.AddForce(Rotation(new Vector2(buttons[(int)Directions.right], 0), rig.rotation) * accelerationx);
                }
                else
                {
                    rig.AddForce(Rotation(new Vector2(UnRotation(relativeVelocity, rig.rotation).x, 0), rig.rotation) * passiveDecelerationx);
                }

                if (relativeVelRotX >= -speedx)
                {
                    rig.AddForce(Rotation(new Vector2(buttons[(int)Directions.left], 0), rig.rotation) * accelerationx);
                }
                else
                {
                    rig.AddForce(Rotation(new Vector2(UnRotation(relativeVelocity, rig.rotation).x, 0), rig.rotation) * passiveDecelerationx);
                }
            }
            render.sprite = normal;
        }
        else 
        {
            //TODO:
            //animation of space drifiting
            render.sprite = flying;
        }

        if (jumpCD == false) count++;
        if (count % 5 == 0) jumpCD = true;
    }

    void LogGravity()
    {
        foreach(var c in orbit.InGravityField)
        {
            Debug.Log(c);
        }
    }
}
