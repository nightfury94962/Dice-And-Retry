using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PauseManager pauseScreen;

    [SerializeField] private GameObject combatDataPrefab;

    [SerializeField] private Animator transition;
    private float transitionTime = 1f;

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

    public void LoadCombatScene(EnnemyScriptOW enemy)
    {
        // Stop musique du jeu
        GameObject music = GameObject.FindGameObjectWithTag("Music");
        if (music != null)
        {
            AudioSource[] musics = music.GetComponents<AudioSource>();
            foreach (AudioSource m in musics)
                m.Stop();
        }

        GameObject go = Instantiate(combatDataPrefab);
        FightData fightData = go.GetComponent<FightData>();
        fightData.Setup();

        transition.gameObject.SetActive(true);
        StartCoroutine(StartGame("Combat"));
    }

    public void LoadMainScene()
    {
        transition.gameObject.SetActive(true);
        StartCoroutine(StartGame("TestScene"));
    }

    private IEnumerator StartGame(string scene)
    {
        transition.SetTrigger("End");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }
}
