using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigInformation : MonoBehaviour
{
    Rigidbody2D rig;
    [SerializeField] private float velocityModule;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocityModule = Mathf.Sqrt(rig.velocity.x * rig.velocity.x + rig.velocity.y * rig.velocity.y);
    }
}
