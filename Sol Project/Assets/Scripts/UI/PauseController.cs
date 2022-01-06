using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class PauseController : MonoBehaviour
{
    public bool IsPlaying { get; private set; } = true;
    private Text[] display;
    // Start is called before the first frame update
    void Start()
    {
        display = GetComponentsInChildren<Text>();
        EnableText(false);
    }

    public void Pause()
    {
        if (IsPlaying)
        {
            Time.timeScale = 0;
            IsPlaying = false;
            EnableText(true);
        }
        else
        {
            Time.timeScale = 1;
            IsPlaying = true;
            EnableText(false);
        }
    }

    private void EnableText(bool enable)
    {
        foreach (Text text in display)
        {
            text.enabled = enable;
        }
        Cursor.visible = enable;
    }
}
