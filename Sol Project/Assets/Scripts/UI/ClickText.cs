using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ClickText : Click, IPointerEnterHandler, IPointerExitHandler
{
    private Color @default;
    private Text text;
    new void Start()
    {
        text = GetComponent<Text>();
        @default = text.color;
        base.Start();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = @default;
    }
}
