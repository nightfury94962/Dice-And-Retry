using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public enum TypeOfPause
    {
        Both,
        Pause,
        GameOver
    }

    [SerializeField] private Image panel;
    [SerializeField] private Text title;
    [SerializeField] private GameObject buttonResume;

    private string sampleScene = "SampleScene";

    [SerializeField] private Animator transition;
    private float transitionTime = 1f;

    private Color gameOverPanelColor = new Color32(255, 0, 18, 100); //new Color(1f, 0f, 7.06f, 35.22f); // RGB(255,0,18,100)
    private Color pausePanelColor = new Color32(125, 125, 125, 100); //new Color(49f, 49f, 49f, 35.22f); // RGB(125,125,125,100)

    public void ShowPauseScreen(TypeOfPause type, bool isShow)
    {
        if (gameObject == null)
            return;

        switch (type)
        {
            case TypeOfPause.GameOver:
                GameManager.isGameOver = isShow;
                panel.color = gameOverPanelColor;
                title.text = "Game Over";
                buttonResume.SetActive(false);
                break;

            case TypeOfPause.Pause:
                GameManager.isPause = isShow;
                panel.color = pausePanelColor;
                title.text = "Pause";
                buttonResume.SetActive(true);
                break;

            case TypeOfPause.Both:
                GameManager.isGameOver = isShow;
                GameManager.isPause = isShow;
                break;
            default:
                break;
        }

        GetComponent<Settings>().CloseAndSaveSettings();

        gameObject.SetActive(isShow);

    }

    public void Resume()
    {
        ShowPauseScreen(TypeOfPause.Both, false);
    }

    public void Retry()
    {
        GameManager.isGameOver = false;
        GameManager.isPause = false;

        StartCoroutine(StartGame(sampleScene));
    }

    public void Quit()
    {
        GameManager.isGameOver = false;
        GameManager.isPause = false;

        StartCoroutine(StartGame("Menu"));
    }

    private IEnumerator StartGame(string scene)
    {
        transition.SetTrigger("End");

        GameObject go = GameObject.FindGameObjectWithTag("Music");
        if (go != null)
        {
            MusicManager music = go.GetComponent<MusicManager>();
            if (music != null)
                music.Stop(); // Stopper la musique
        }

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
        foreach (GameObject _go in GameManager.instance.gameObject.scene.GetRootGameObjects())
        {
            Destroy(_go);
        }
    }
}
