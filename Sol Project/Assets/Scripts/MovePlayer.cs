using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Physics2D;
using static NiceMethods;

public class MovePlayer : MonoBehaviour
{
    private Player player;
    enum ControlType { Type1, Type2 }
    [SerializeField] ControlType controlType;
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
    private Stats stats;

    public void Awake()
    {
        player = new Player();
        player.Gameplay.Jump.started += ctx => Jump();
        player.Gameplay.RunRight.started += ctx => Run(Directions.right, true);
        player.Gameplay.RunRight.canceled += ctx => Run(Directions.right, false);
        player.Gameplay.RunLeft.started += ctx => Run(Directions.left, true);
        player.Gameplay.RunLeft.canceled += ctx => Run(Directions.left, false);
    }

    void Run(Directions dir, bool set)
    {
        if (dir == Directions.right) buttons[(int)Directions.right] = set ? 1 : 0;
        if (dir == Directions.left) buttons[(int)Directions.left] = set ? -1 : 0;
        buttons[(int)Directions.stop] = buttons[(int)Directions.right] + buttons[(int)Directions.left];
    }

    void Jump()
    {
        if (OverlapCircle(jumpCheck.position, 0.1f, level) && jumpCD)
        {
            float jumpForce = this.jumpForce * stats.JumpFactor;
            rig.AddRelativeForce(new Vector2(0, jumpForce));
            jumpCD = false; count = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        transf = GetComponent<Transform>();
        orbit = GetComponent<Orbit>();
        render = GetComponent<SpriteRenderer>();
        stats = GetComponent<Stats>();
        buttons = new int[Enum.GetValues(typeof(Directions)).Length];

        if (decelerationx > 0) decelerationx *= -1;
        if (passiveDecelerationx > 0) passiveDecelerationx *= -1;

        player.Gameplay.Enable();
    }

    // Update is called once per frame
    //void Update() { }

    [NonSerialized] public byte count = 0;
    void FixedUpdate()
    {
        float speedx = this.speedx * stats.speedFactor;
        float passiveDecelerationx = this.passiveDecelerationx * stats.speedFactor;
        float accelerationx = this.accelerationx * stats.speedFactor;

        Collider2D[] orbitings = orbit.InGravityField;
        if ((orbitings.Length == 1 || (orbit.GravityType == 2 || orbit.GravityType == 3) && orbitings.Length > 0) && orbit.GravityType != 4)
        {
            Vector2 relativeVelocity;
            if (orbitings[0].TryGetComponentInParent(out Rigidbody2D rigTarget))
            {
                Vector2 rotationVelocity = followRotation ?
                rigTarget.angularVelocity.ToLinearVelocity(transf.position, rigTarget.position) : Vector2.zero;
                relativeVelocity = rig.velocity - rigTarget.velocity - rotationVelocity;
            }
            else
            {
                relativeVelocity = rig.velocity;
            }

            if (controlType == ControlType.Type2)
            {
                Vector2 playerVector = player.Gameplay.RunAny.ReadValue<Vector2>().normalized;
                playerVector = Rotation(new Vector2(UnRotation(playerVector, rig.rotation).x, 0), rig.rotation);

                float relativeVelRotX = UnRotation(relativeVelocity, rig.rotation).x;
                if (playerVector.magnitude <= 0.4f)
                {
                    rig.AddForce(Rotation(new Vector2(UnRotation(relativeVelocity, rig.rotation).x, 0), rig.rotation) * decelerationx);
                }
                else
                {
                    if (Mathf.Abs(relativeVelRotX) <= speedx)
                    {
                        rig.AddForce(playerVector.normalized * accelerationx);
                    }
                    else
                    {
                        rig.AddForce(Rotation(new Vector2(UnRotation(relativeVelocity, rig.rotation).x, 0), rig.rotation) * passiveDecelerationx);
                    }
                }
            }

            else if (controlType == ControlType.Type1)
            {
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
        foreach (var c in orbit.InGravityField)
        {
            Debug.Log(c);
        }
    }
}
