using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
{
    public static InteractButton instance;
    public bool buttonPressed;
    public bool buttonUp;
    private void Awake()
    {
        instance = this;
    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
       
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        buttonPressed = true;

        Debug.Log("Button pressed");
    }
}
