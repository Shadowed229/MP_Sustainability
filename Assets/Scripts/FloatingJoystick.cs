using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(RectTransform))]
[DisallowMultipleComponent]
public class FloatingJoystick : MonoBehaviour
{
    [HideInInspector]
    public static FloatingJoystick instance;
    public RectTransform rectTransform;
    public RectTransform knob;


    private void Awake()
    {
        instance = this;
        rectTransform = GetComponent<RectTransform>();
    }
}
