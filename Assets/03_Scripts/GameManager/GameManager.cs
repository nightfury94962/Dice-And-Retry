using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PauseManager pauseScreen;

    public static bool isPause;
    public static bool isGameOver;

    /* Singleton */
    public static GameManager instance;

    void Awake()
    {
        /* Singleton */
        if (instance != null)
        {
            Debug.LogError("Plus d'une instance GameManager existe!");
            return;
        }

        instance = this;
    }

    private void Update()
    {
        if (isGameOver)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        pauseScreen.ShowPauseScreen(PauseManager.TypeOfPause.Pause, !isPause);
    }

    public void GameOver()
    {
        if (GameManager.isGameOver)
            return;

        isGameOver = true;

        pauseScreen.ShowPauseScreen(PauseManager.TypeOfPause.GameOver, true);
    }
}
