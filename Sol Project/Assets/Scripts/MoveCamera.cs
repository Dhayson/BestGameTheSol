using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using static DLL;

public class MoveCamera : MonoBehaviour
{
    private Rigidbody2D rig;
    public float defaultSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
