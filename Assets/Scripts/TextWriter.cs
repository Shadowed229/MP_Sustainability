using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    public Text uiText; //Text Variable for us to directly edit and change the texts
    private string textToWrite; //string variable which we will then use it to store the texts that we want to generate 
    private int characterIndex;
    private float timePerCharacter;
    private float timer; //to prevent the code from repeating while generating text
    private bool invisibleCharacters;
    public bool isGeneratingText;

    //function to get the ref for the text we want to write and the speed of text being generated 
    public void AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        this.invisibleCharacters = invisibleCharacters;
        characterIndex = 0;
    }

    private void Awake()
    {
        //set the initial bool value to false
        isGeneratingText = false;

    }
    private void Update()
    {
        if (uiText != null)
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                isGeneratingText = true;
                // display character
                timer += timePerCharacter;
                characterIndex++;
                //use the substring function to get all the individual characters that we will be generating 
                string text = textToWrite.Substring(0, characterIndex);

                if (invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }
                uiText.text = text;

                if (characterIndex >= textToWrite.Length)
                {
                    uiText = null;
                    return;
                }
            }
        }
    }

}
