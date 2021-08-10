using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NiceMethods;

abstract public class ChangeGravityType : MonoBehaviour
{
    [SerializeField] private LayerMask player;
    abstract public byte GravityType { get; }
    private GameObject parent;

    public void Start()
    {
        parent = GetComponent<Transform>().parent.gameObject;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Player = collision.gameObject;
        if (CompareLayer(Player.layer, player) && Player.TryGetComponent(out Orbit playerOrb))
        {
            playerOrb.IntoCollider(GravityType, parent);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        GameObject Player = collision.gameObject;
        if (CompareLayer(Player.layer, player) && Player.TryGetComponent(out Orbit playerOrb))
        {
            playerOrb.OutCollider(GravityType, parent);
        }
    }
}
