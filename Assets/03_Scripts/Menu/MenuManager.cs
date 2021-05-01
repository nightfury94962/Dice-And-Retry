using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject settings;
    [SerializeField] private Animator transition;
    private float transitionTime = 1f;

    public void Play()
    {
        Settings.instance.SaveSettings();

        transition.gameObject.SetActive(true);

        // Lancer la Scene: MainScene
        StartCoroutine(StartGame("Introduction"));
    }

    private IEnumerator StartGame(string scene)
    {
        transition.SetTrigger("End");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }

    public void ShowSettings()
    {
        settings.SetActive(true);
    }
}
