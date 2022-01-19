using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(RectTransform))]
public class Click : MonoBehaviour
{
    [SerializeField] private Component trigger;
    [SerializeField] private string triggerMethod;
    private BoxCollider2D col2D;
    private Collider2D col;
    private RectTransform rect;
    private MethodInfo method;
    protected void Start()
    {
        method = trigger.GetType().GetMethod(triggerMethod);
        if (method is null) Debug.LogError($"{triggerMethod} doesn't exist in this object");
        col = GetComponent<Collider2D>();
        if (col.GetType() == typeof(BoxCollider2D))
        {
            col2D = GetComponent<BoxCollider2D>();
        }
        rect = GetComponent<RectTransform>();
    }
    protected void Update()
    {
        //make the collider size match the text size
        col2D.size = rect.sizeDelta;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = NiceMethods.MouseClick(Camera.main);
            if (hit && hit.collider.gameObject == gameObject && gameObject.activeInHierarchy)
            {
                method.Invoke(trigger, null);
            }
        }
    }
}