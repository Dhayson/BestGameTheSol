using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowArea : MonoBehaviour
{
    [SerializeField] private float slowRatio;
    [SerializeField] private LayerMask target;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var colGameObj = collision.gameObject;
        if (NiceMethods.CompareLayer(colGameObj.layer, target))
        {
            if (colGameObj.TryGetComponent(out Orbit orb))
            {
                orb.gravityFactor *= slowRatio;
            }

            if (colGameObj.TryGetComponent(out Stats stats))
            {
                stats.speedFactor *= slowRatio;
                stats.jumpFactor *= Mathf.Sqrt(slowRatio);
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
                orb.gravityFactor /= slowRatio;
            }

            if (colGameObj.TryGetComponent(out Stats stats))
            {
                stats.speedFactor /= slowRatio;
                stats.jumpFactor /= Mathf.Sqrt(slowRatio);
            }
        }
    }
}