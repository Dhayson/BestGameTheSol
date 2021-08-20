using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NiceMethods;


[RequireComponent(typeof(Collider2D))]
abstract public class GravityContext : MonoBehaviour
{
    enum TargetOption { parent, self }

    [SerializeField] private LayerMask player;
    [SerializeField] private Order order;
    [SerializeField] private TargetOption targetSelect;
    abstract public byte GravityType { get; }
    private GameObject target;
    private bool started = false;

    public void OnStart()
    {
        if (targetSelect == TargetOption.parent) target = GetComponent<Transform>().parent.gameObject;
        else if (targetSelect == TargetOption.self) target = gameObject;
        started = true;
    }

    public void Start()
    {
        OnStart();
    }

    public void OnEnable()
    {
        if (started) TriggerAll(OnTriggerEnter2D);
    }

    public void OnDisable()
    {
        if (started) TriggerAll(OnTriggerExit2D);
    }

    private void TriggerAll(Action<Collider2D> Trigger)
    {
        var thisCol = GetComponent<Collider2D>();
        List<Collider2D> Colliders = new List<Collider2D>();
        thisCol.OverlapCollider(new ContactFilter2D().NoFilter(), Colliders);
        foreach (var Collider in Colliders)
        {
            Trigger(Collider);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Player = collision.gameObject;
        if (CompareLayer(Player.layer, player) && Player.TryGetComponent(out Orbit playerOrb) && enabled)
        {
            playerOrb.IntoCollider(this, target, order);
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
