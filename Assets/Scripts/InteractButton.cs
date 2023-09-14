using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractButton : MonoBehaviour, IPointerClickHandler
{
    public static InteractButton instance; //public static var referencing to the script itself so that other script can access to other var in this script such as bool buttonPressed
    public bool buttonPressed; //bool to check if the button has been pressed


    //when the script is first called, (awake), it will declare the instance to be this script. This is to ensure theres only one instance of script that the system can ref to (incase there are multiple of the InteractBtn is called/present in the scene, but that shouldn’t be happening)
    private void Awake()
    {
        instance = this;
    }
    //when the button is being clicked/pressed in the scene, it will return the bool buttonPressed to be true, which will then be ref from different script and carry out certain action according to the situation
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        buttonPressed = true;
        StartCoroutine(ResetButton());
    }

    //This coroutine is called in case the button is pressed but theres no responsive function that refers back to this script which should turn back the bool value of buttonPressed to false. In case that happens, to prevent any bugs, we will manually change back the bool value to false if the bool value don’t turn back to false after 0.5 seconds
    IEnumerator ResetButton()
    {
        while (buttonPressed == true)
        {
            yield return new WaitForSeconds(0.5f);
            buttonPressed = false;
        }

    }

}
