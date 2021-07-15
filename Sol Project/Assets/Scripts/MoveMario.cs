using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Physics2D;
using static NiceMethods;

public class MoveMario : MonoBehaviour
{
    public Sprite flying;
    public Sprite normal;
    private bool jumpCD;
    public float speed;
    public float jumpForce;
    public Transform jumpCheck;
    public LayerMask level;

    enum Directions { right, left, stop, vertical, clock };
    private int[] buttons;

    private Rigidbody2D rig;
    private Orbit orbit;
    private SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        orbit = GetComponent<Orbit>();
        render = GetComponent<SpriteRenderer>();
        buttons = new int[Enum.GetValues(typeof(Directions)).Length];
    }

    // Update is called once per frame
    void Update()
    {
        buttons[(int)Directions.right] = Input.GetKey(KeyCode.D) ? 1 : 0;
        buttons[(int)Directions.left] = Input.GetKey(KeyCode.A) ? -1 : 0;
        buttons[(int)Directions.stop] = buttons[(int)Directions.right] + buttons[(int)Directions.left];
        float jump = Input.GetKeyDown(KeyCode.Space) ? jumpForce : 0;

        buttons[(int)Directions.clock] = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) - (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0);

        Collider2D[] orbitings = orbit.Orbitings;
        if (orbitings.Length == 1)
        {
            Vector2 princOrbitVelocity = orbitings[0].GetComponentInParent<Rigidbody2D>().velocity;
            if (buttons[(int)Directions.stop] == 0)
            {
                rig.AddForce(-0.5f*Rotation(new Vector2(UnRotation(rig.velocity - princOrbitVelocity, rig.rotation).x, 0), rig.rotation));
            }
            else
            {
                if (UnRotation(rig.velocity - princOrbitVelocity, rig.rotation).x <= speed)
                {
                    rig.AddForce(Rotation(new Vector2(buttons[(int)Directions.right], 0) * speed, rig.rotation));
                }
                if (UnRotation(rig.velocity - princOrbitVelocity, rig.rotation).x >= -speed)
                {
                    rig.AddForce(Rotation(new Vector2(buttons[(int)Directions.left], 0) * speed, rig.rotation));
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

        if (Input.GetKeyDown(KeyCode.Space) && OverlapCircle(jumpCheck.position, 0.1f, level) && jumpCD)
        {
            //rig.AddForce(Rotation(new Vector2(0, jump),rig.rotation));
            rig.AddRelativeForce(new Vector2 (0, jump));
            jumpCD = false; count = 0;
        }
    }

    int count = 0;
    void FixedUpdate()
    {
        count++;
        if(count % 3 == 0)
        {
            jumpCD = true;
        }
    }
}
