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
        // A n'import quel touche
        if (Input.GetMouseButtonDown(0) ||
            Input.GetMouseButtonDown(1) ||
            Input.GetMouseButtonDown(2) ||
            Input.anyKey)
        {
            // L'affichage de la phrase n'est pas complete
            if(!onComplete)
                this.currentTimePerCharacter = 0.03f; // Accélerer l'affichage du texte

            // Sinon toutes les phrases ont été affichées
            else if (scenarioIndex >= textToWrite.Length-1)
            {
                transition.gameObject.SetActive(true);
                StartCoroutine(StartGame(this.sceneName)); // Charger la scene suivante
                return;
            }
            // Sinon phrase suivante
            else
            {
                uiText.text = string.Empty;
                this.currentTimePerCharacter = this.timePerCharacter;
                this.characterIndex = 0;
                this.onComplete = false;
                scenarioIndex++;
            }
        }

        // Tant que l'affichage de la phrase n'est pas complete
        if (!onComplete)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                // Afficher le caractère suivant
                timer += currentTimePerCharacter;
                characterIndex++;
                uiText.text = textToWrite[scenarioIndex].Substring(0, characterIndex);

                if(characterIndex >= textToWrite[scenarioIndex].Length)
                {
                    // Toute la phrase a été affichée
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
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicManager>().Stop(); // Stopper la musique
    }
}
