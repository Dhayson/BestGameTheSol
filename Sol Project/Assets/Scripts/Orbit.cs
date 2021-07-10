using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static DLL;

public class Orbit : MonoBehaviour
{
    private Rigidbody2D rig;
    [SerializeField] private GameObject orbited;
    public float speedx;
    public float speedy;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = new Vector2(speedx, speedy);
        Debug.Log(AppDomain.CurrentDomain.BaseDirectory);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 p1 = GetComponent<Transform>().position;
        Vector2 p2 = orbited.transform.position;
        rig.AddForce(rig.mass*orbited.GetComponent<Rigidbody2D>().mass*Direction(p1, p2)/
            Distance(p1.x,p1.y,p2.x,p2.y));

        
    }

    Vector2 Direction(Vector2 p1, Vector2 p2)
    {
        Vector2 toReturn = new Vector2(p2.x - p1.x, p2.y - p1.y);
        toReturn.Normalize();
        return toReturn;
    }

    t DistanceSquared<t>(Vector2 p1, Vector2 p2)
    {
        float result = (p2.x-p1.x)*(p2.x-p1.x)+(p2.y-p1.y)*(p2.y-p1.y);
        return (t)Convert.ChangeType(result, typeof(t));
    }
    
    [DllImport("DLLTeste.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern float Distance(float x1, float y1, float x2, float y2);
}
