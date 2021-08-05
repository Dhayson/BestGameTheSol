using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NiceMethods;

public class ChangeGravityType : MonoBehaviour
{
    [SerializeField] private LayerMask player;
    public Vector2 direction;
    public float rotation;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Player = collision.gameObject;
        if (CompareLayer(Player.layer, player) && Player.TryGetComponent(out Orbit playerOrb) && playerOrb.AllowGravityChange)
        {
            /*playerOrb.gravityType = 2;*/
            playerOrb.IntoColliderAlert(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        GameObject Player = collision.gameObject;
        if (CompareLayer(Player.layer, player) && Player.TryGetComponent(out Orbit playerOrb) && playerOrb.AllowGravityChange)
        {
            /*playerOrb.gravityType = playerOrb.GravityTypeStart;*/
            playerOrb.IntoColliderAlert(false);
        }
    }
}
