using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Component trigger;
    [SerializeField] private string triggerMethod;
    private MethodInfo method;
    protected void Start()
    {
        method = trigger.GetType().GetMethod(triggerMethod);
        if (method is null) Debug.LogError($"{triggerMethod} doesn't exist in this object");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        method.Invoke(trigger, null);
    }

}