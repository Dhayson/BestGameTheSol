using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRig : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speedx;
    public float speedy;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = new Vector2(speedx, speedy);
    }
}
