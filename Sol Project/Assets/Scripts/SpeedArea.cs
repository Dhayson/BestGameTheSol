using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SpeedArea : SpeedEffect
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var colGameObj = collision.gameObject;
        if (NiceMethods.CompareLayer(colGameObj.layer, target))
        {
            if (colGameObj.TryGetComponent(out Orbit orb))
            {
                orb.gravityFactor *= gravityRatio;
            }

            if (colGameObj.TryGetComponent(out Stats stats))
            {
                stats.speedFactor *= speedRatio;
                stats.jumpFactor *= jumpRatio;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        var colGameObj = collision.gameObject;
        if (NiceMethods.CompareLayer(colGameObj.layer, target))
        {
            if (colGameObj.TryGetComponent(out Orbit orb))
            {
                orb.gravityFactor /= gravityRatio;
            }

            if (colGameObj.TryGetComponent(out Stats stats))
            {
                stats.speedFactor /= speedRatio;
                stats.jumpFactor /= jumpRatio;
            }
        }
    }
}
