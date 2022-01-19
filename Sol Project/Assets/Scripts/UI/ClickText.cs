using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ClickText : Click
{
    private Color @default;
    private Text text;
    new void Start()
    {
        text = GetComponent<Text>();
        @default = text.color;
        base.Start();
    }
    new void Update()
    {
        base.Update();
        RaycastHit2D hit = NiceMethods.MouseClick(Camera.main);
        if (hit && hit.collider.gameObject == gameObject && gameObject.activeInHierarchy)
        {
            text.color = Color.white;
        }
        else
        {
            text.color = @default;
        }
    }
}
