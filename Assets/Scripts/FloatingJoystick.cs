using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(RectTransform))]
[DisallowMultipleComponent]
public class FloatingJoystick : MonoBehaviour
{
    [HideInInspector]
    public static FloatingJoystick instance;
    public RectTransform rectTransform; //rectTransform of the whole joysticks gameobject
    public RectTransform knob; //rectTransform of the knob inside the joystick


    private void Awake()
    {
        instance = this;
        rectTransform = GetComponent<RectTransform>(); //getting component of recttransform to refer from different script
    }
}
