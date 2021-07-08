using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rig;
    public GameObject orbited;
    public float speedx;
    public float speedy;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = new Vector2(speedx, speedy);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 p1 = GetComponent<Transform>().position;
        Vector2 p2 = orbited.transform.position;
        rig.AddForce(500*Direction(p1, p2)/DistanceSquared(p1,p2));
    }

    Vector2 Direction(Vector2 p1, Vector2 p2)
    {
        Vector2 toReturn = new Vector2(p2.x - p1.x, p2.y - p1.y);
        toReturn.Normalize();
        return toReturn;
    }

    float DistanceSquared(Vector2 p1, Vector2 p2)
    {
        return (p2.x - p1.x) * (p2.x - p1.x) + (p2.y - p1.y) * (p2.y - p1.y);
    }
}
