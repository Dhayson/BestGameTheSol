using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowArea : MonoBehaviour
{
    [SerializeField] private float allSlowRatio;
    [SerializeField] private float speedRatio;
    [SerializeField] private float jumpRatio;
    [SerializeField] private float gravityRatio;
    [SerializeField] private LayerMask target;

    public void Start()
    {
        if (allSlowRatio != 0)
        {
            speedRatio = jumpRatio = gravityRatio = allSlowRatio;
        }
    }

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
