using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
{
    public static InteractButton instance;
    public bool buttonPressed;
    public bool buttonHold;
    public bool buttonUp;
    float clickTime = 0.01f;
    bool clickable = true;

    private void Awake()
    {
        instance = this;
    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
      //  buttonHold = true;
       
    }
    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
       // buttonUp = true;
    }
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if(clickable == true)
        {
            clickable = false;
            buttonPressed = true;
        }
        
    }

    private void Update()
    {
        checkClick();
    }
    void checkClick()
    {
        
        if (clickable == false)
        {
            
            buttonPressed = false;
            clickTime -= Time.deltaTime;
            Debug.Log(clickTime);

            if (clickTime <= 0)
            {
                
                clickTime = 0.01f;
                clickable = true;
            }
        }
    }
}
