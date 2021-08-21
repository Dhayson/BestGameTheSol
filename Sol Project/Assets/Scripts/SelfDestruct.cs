using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public void Start()
    {
        if(!Application.isEditor)
        {
            enabled = false;
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(gameObject, 0);
        }
    }
}
