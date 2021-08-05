using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NiceMethods;

public class BuffJump : MonoBehaviour
{
    [SerializeField] private LayerMask player;
    [SerializeField] private float Multiplier;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Player = collision.gameObject;
        if(CompareLayer(Player.layer,player))
        {
            Player.GetComponent<MovePlayer>().jumpForce *= Multiplier;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        GameObject Player = collision.gameObject;
        if (CompareLayer(Player.layer, player))
        {
            Player.GetComponent<MovePlayer>().jumpForce /= Multiplier;
        }
    }
}
