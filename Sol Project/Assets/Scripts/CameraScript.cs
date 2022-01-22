using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform follow;
    private Rigidbody2D rig;
    private Transform pos;
    public float Speed;
    public float AngularSpeed;
    private int[] buttons;

    enum Directions { horizontal, vertical, clock };


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        pos = GetComponent<Transform>();
        buttons = new int[Enum.GetValues(typeof(Directions)).Length];
    }

    // Update is called once per frame
    void Update()
    {
        /*
        buttons[(int)Directions.clock] =
            (Input.GetKey(KeyCode.LeftArrow) ? -1 : 0) +
            (Input.GetKey(KeyCode.RightArrow) ? 1 : 0);
        */
        rig.angularVelocity = AngularSpeed * buttons[(int)Directions.clock];
        pos.position = new Vector3(follow.position.x, follow.position.y, pos.position.z);
    }
}
