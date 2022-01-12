using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceGameQuit : MonoBehaviour
{
    private DebugKeys debugKeys;
    public void Awake()
    {
        debugKeys = new DebugKeys();
        debugKeys.debug.Quit.started += ctx => Quit();
    }
    void Start()
    {
        if (NiceMethods.debug)
        {
            debugKeys.Enable();
        }
    }
    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
