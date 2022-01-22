using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boca : MonoBehaviour
{
    private Collider2D col;
    [SerializeField] LayerMask entity;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (NiceMethods.CompareLayer(trigger.gameObject.layer, entity))
        {
            if (trigger.gameObject.TryGetComponent(out Stats stats))
            {
                stats.Kill();
            }
        }
    }
}
