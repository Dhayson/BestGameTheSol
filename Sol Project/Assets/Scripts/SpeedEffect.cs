using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class SpeedEffect : MonoBehaviour
{
    [SerializeField] protected float allSlowRatio;
    [SerializeField] protected float speedRatio;
    [SerializeField] protected float jumpRatio;
    [SerializeField] protected float gravityRatio;
    [SerializeField] protected LayerMask target;

    public void Start()
    {
        if (allSlowRatio != 0)
        {
            speedRatio = jumpRatio = gravityRatio = allSlowRatio;
        }
    }
}
