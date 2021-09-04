using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static NiceMethods;

public class CameraScript : MonoBehaviour
{
    private DebugKeys debugKeys;

    private Rigidbody2D rig;
    private bool hasRig = false;
    private Transform pos;
    public float Speed;
    public float AngularSpeed;
    private int[] buttons;

    enum Directions {horizontal, vertical, clock};

    public void Awake()
    {
        debugKeys = new DebugKeys();
        debugKeys.debug.Quit.started += ctx => Quit();
    }

    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(TryGetComponent(out rig))
        {
            hasRig = true;
        }
        pos = GetComponent<Transform>();
        buttons = new int[Enum.GetValues(typeof(Directions)).Length];

        if(debug)
        {
            debugKeys.Enable();
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        buttons[(int)Directions.clock] =
            (Input.GetKey(KeyCode.LeftArrow) ? -1 : 0) +
            (Input.GetKey(KeyCode.RightArrow) ? 1 : 0);
        */
        if (hasRig)
        {
            rig.angularVelocity = AngularSpeed * buttons[(int)Directions.clock];
            pos.localPosition = new Vector3(0, 0, pos.localPosition.z);
        }
    }
}
