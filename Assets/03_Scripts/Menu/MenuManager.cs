using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject settings;

    public void Play()
    {
        Settings.instance.SaveSettings();

        // Lancer la Scene: MainScene
        SceneManager.LoadScene("Introduction");
    }

    public void ShowSettings()
    {
        settings.SetActive(true);
    }
}
