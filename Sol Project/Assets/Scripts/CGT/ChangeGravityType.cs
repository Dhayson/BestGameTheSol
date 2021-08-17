using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NiceMethods;

abstract public class ChangeGravityType : MonoBehaviour
{
    enum TargetOption { parent, self}

    [SerializeField] private LayerMask player;
    [SerializeField] private Order order;
    [SerializeField] private TargetOption targetSelect;
    abstract public byte GravityType { get; }
    private GameObject target;

    public void Start()
    {
        if (targetSelect == TargetOption.parent) target = GetComponent<Transform>().parent.gameObject;
        else if (targetSelect == TargetOption.self) target = gameObject;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Player = collision.gameObject;
        if (CompareLayer(Player.layer, player) && Player.TryGetComponent(out Orbit playerOrb))
        {
            playerOrb.IntoCollider(GravityType, target, order);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        GameObject Player = collision.gameObject;
        if (CompareLayer(Player.layer, player) && Player.TryGetComponent(out Orbit playerOrb))
        {
            playerOrb.OutCollider(target);
        }
    }
}
