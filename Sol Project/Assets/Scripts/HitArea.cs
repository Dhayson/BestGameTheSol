using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NiceMethods;

public class HitArea : MonoBehaviour
{
    private Collider2D col;
    [SerializeField] int damage;
    public LayerMask player;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DamageOnContact(col, player, damage);
    }
}
