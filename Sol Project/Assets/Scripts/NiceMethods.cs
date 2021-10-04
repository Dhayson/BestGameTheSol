using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static UnityEngine.Mathf;
using System.Linq;

static public class NiceMethods
{
    //put this on config file or smth
    static readonly public bool debug = true;

    static public unsafe Vector2 Rotation(Vector2 v, float angle)
    {
        float* values = DLL.Rotation(v.x, v.y, angle);
        Vector2 toReturn = new Vector2(*values, *(values + 1));
        DLL.DeleteArrayF(ref values);
        return toReturn;
    }

    static public unsafe Vector2 UnRotation(Vector2 v, float angle)
    {
        float* values = DLL.UnRotation(v.x, v.y, angle);
        Vector2 toReturn = new Vector2(*values, *(values + 1));
        DLL.DeleteArrayF(ref values);
        return toReturn;
    }

    /// <summary>
    /// Returns the Vector2 that represents the direction between two points in 2D space
    /// 
    /// The difference between two Vector2, normalized
    /// </summary>
    static public Vector2 Direction(Vector2 p1, Vector2 p2)
    {
        return (p2 - p1).normalized;
    }

    /// <summary>
    /// Returns the antitangent of a Vector2 in degrees
    /// </summary>
    static public float VectorAngle(Vector2 v)
    {
        return Atan2(v.y, v.x) * 180 / PI;
    }

    static public float DistanceSquared(Vector2 p1, Vector2 p2)
    {
        return (p2.x - p1.x) * (p2.x - p1.x) + (p2.y - p1.y) * (p2.y - p1.y);
    }

    static public void InvertSpeed(ref Rigidbody2D r)
    {
        r.velocity = new Vector2(-r.velocity.x, -r.velocity.y);
    }

    static public void Stun(ref Rigidbody2D r)
    {
        r.velocity = new Vector2(0, 0);
    }

    /// <summary>
    /// Check if a Layer is contained in a LayerMask
    /// </summary>
    static public bool CompareLayer(int layer, LayerMask layermask)
    {
        //https://answers.unity.com/questions/50279/check-if-layer-is-in-layermask.html
        return layermask == (layermask | (1 << layer));
    }

    static public void DamageOnContact(Collider2D col, LayerMask layer, int damage)
    {
        List<Collider2D> allContacts = new List<Collider2D>();
        Physics2D.OverlapCollider(col, new ContactFilter2D().NoFilter(), allContacts);
        foreach (Collider2D c in allContacts)
        {
            GameObject playerG = c.gameObject;
            if (CompareLayer(playerG.layer, layer) && playerG.TryGetComponent(out Stats stats))
            {
                stats.Damage(damage);
            }
        }
    }

    static public bool TryGetComponentInChildren<t>(this GameObject g, out t c, bool includeInactive = false) where t : Component
    {
        c = g.GetComponentInChildren<t>(includeInactive);
        return !(c is null);
    }

    static public bool TryGetComponentInParent<t>(this GameObject g, out t c, bool includeInactive = false) where t : Component
    {
        c = g.GetComponentInParent<t>(includeInactive);
        return !(c is null);
    }

    static public bool TryGetComponentInParent<t>(this Component g, out t c) where t : Component
    {
        c = g.GetComponentInParent<t>();
        return !(c is null);
    }

    /// <summary>
    /// Removes nulls, nones, inactives and duplicates from the list
    /// </summary>
    static public IList<GameObject> TrimList(IList<GameObject> list)
    {
        list = list.Distinct().ToList();
        list = list.Where(x => x != null && x.activeSelf).ToList();
        return list;
    }

    static public Vector2 ToLinearVelocity(this float angularVelocity, Vector2 pThis, Vector2 pTarget)
    {
        return Rotation(Deg2Rad * angularVelocity * (pTarget - pThis), 270);
    }

    public enum Order { First, Last }
}
