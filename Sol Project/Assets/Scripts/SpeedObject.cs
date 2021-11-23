using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sprite))]
[RequireComponent(typeof(Collider2D))]
public class SpeedObject : SpeedEffect
{
    [SerializeField] private float timer;

    private Collider2D col;
    private SpriteRenderer sprite;

    new public void Start()
    {
        base.Start();
        col = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
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

            StartCoroutine(TimerEnd(orb, stats));
            col.enabled = false;
            sprite.enabled = false;
        }
    }

    public IEnumerator TimerEnd(Orbit orb, Stats stats)
    {
        yield return new WaitForSeconds(timer);
        if (orb != null) orb.gravityFactor /= gravityRatio;
        if (stats != null)
        {
            stats.speedFactor /= speedRatio;
            stats.jumpFactor /= jumpRatio;
        }

        Destroy(gameObject);
    }
}
