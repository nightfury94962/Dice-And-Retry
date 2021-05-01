using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    [SerializeField] private Animator transition;
    private float transitionTime = 1f;

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
                StartCoroutine(StartGame(this.sceneName));
                GameObject.FindGameObjectWithTag("Music").GetComponent<MusicManager>().Stop();
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

    private IEnumerator StartGame(string scene)
    {
        transition.SetTrigger("End");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }
}
