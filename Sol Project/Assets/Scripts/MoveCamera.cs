using System;
using UnityEngine;
using static NiceMethods;

public class MoveCamera : MonoBehaviour
{
    private Rigidbody2D rig;
    private bool hasRig = false;
    private Transform pos;
    public float Speed;
    public float AngularSpeed;
    private int[] buttons;

    enum Directions {horizontal, vertical, clock};
    // Start is called before the first frame update
    void Start()
    {
        if(TryGetComponent(out rig))
        {
            hasRig = true;
        }
        pos = GetComponent<Transform>();
        buttons = new int[Enum.GetValues(typeof(Directions)).Length];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }

        if (hasRig)
        {
            rig.angularVelocity = AngularSpeed * buttons[(int)Directions.clock];
        }
    }
}
