using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractButton : MonoBehaviour, IPointerClickHandler
{
    public static InteractButton instance;
    public bool buttonPressed;
    public bool buttonHold;
    public bool buttonUp;

    private void Awake()
    {
        instance = this;
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        buttonPressed = true;
        StartCoroutine(ResetButton());
    }

    IEnumerator ResetButton()
    {
        while(buttonPressed == true)
        {
            yield return new WaitForSeconds(0.5f);
            buttonPressed = false;
        }
        
    }
}
