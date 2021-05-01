using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private Text uiText;
    private string[] textToWrite;
    private int characterIndex;
    private int scenarioIndex;
    private float timePerCharacter;
    private float currentTimePerCharacter;
    private float timer;
    private string sceneName;
    private bool onComplete;

    public void AddWriter(Text uiText, string[] textToWrite, float timePerCharacter, string sceneName)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        this.currentTimePerCharacter = timePerCharacter; ;
        this.sceneName = sceneName;
        this.scenarioIndex = 0;
        this.characterIndex = 0;
        this.onComplete = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(!onComplete)
                this.currentTimePerCharacter = 0.03f;

            else if (scenarioIndex >= textToWrite.Length-1)
            {
                SceneManager.LoadScene(this.sceneName);
                return;
            }
            else
            {
                uiText.text = string.Empty;
                this.characterIndex = 0;
                this.onComplete = false;
                this.currentTimePerCharacter = this.timePerCharacter;
                scenarioIndex++;
            }
        }

        if (!onComplete)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                // Display next character
                timer += currentTimePerCharacter;
                characterIndex++;
                uiText.text = textToWrite[scenarioIndex].Substring(0, characterIndex);

                if(characterIndex >= textToWrite[scenarioIndex].Length)
                {
                    // Entire string displayed
                    onComplete = true;
                    return;
                }
            }
        }
    }
}
