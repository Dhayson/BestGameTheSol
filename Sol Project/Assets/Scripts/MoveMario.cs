using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Physics2D;
using static NiceMethods;

public class MoveMario : MonoBehaviour
{
    [SerializeField] bool jumpCD;

    public float speed;
    public float jumpForce;
    public Transform jumpCheck;
    public LayerMask level;

    enum Directions { right, left, vertical, clock };
    private int[] buttons;
    Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        buttons = new int[Enum.GetValues(typeof(Directions)).Length];
    }

    // Update is called once per frame
    void Update()
    {
        buttons[(int)Directions.right] = Input.GetKey(KeyCode.D) ? 1 : 0;
        buttons[(int)Directions.left] = Input.GetKey(KeyCode.A) ? -1 : 0;
        float jump = Input.GetKeyDown(KeyCode.Space) ? jumpForce : 0;

        buttons[(int)Directions.clock] = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) - (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0);

        if (UnRotation(rig.velocity, rig.rotation).x <= speed)
        {
            rig.AddForce(Rotation(new Vector2(buttons[(int)Directions.right], 0).normalized * speed, rig.rotation));
        }
        if (UnRotation(rig.velocity, rig.rotation).x >= -speed)
        {
            rig.AddForce(Rotation(new Vector2(buttons[(int)Directions.left], 0).normalized * speed, rig.rotation));
        }

        if (Input.GetKeyDown(KeyCode.Space) && OverlapCircle(jumpCheck.position, 0.1f, level) && jumpCD)
        {
            rig.AddForce(Rotation(new Vector2(0, jump),rig.rotation));
            jumpCD = false;
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
