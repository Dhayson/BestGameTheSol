using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GravityContext2))]
public class Invert : MonoBehaviour
{
    private GravityContext2 GC2;
    [SerializeField] private Collider2D colNormal;
    [SerializeField] private Collider2D colInverted;

    // Start is called before the first frame update
    void Start()
    {
        GC2 = GetComponent<GravityContext2>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (NiceMethods.CompareLayer(collision.gameObject.layer, GC2.player))
        {
            if (collision.IsTouching(colNormal))
            {
                GC2.BaseDirection = GC2.StartDirection;
                GC2.BaseRotation = GC2.StartRotation;
            }
            else if (collision.IsTouching(colInverted))
            {
                GC2.BaseDirection = -GC2.StartDirection;
                GC2.BaseRotation = -GC2.StartRotation;
            }
        }
    }
}
