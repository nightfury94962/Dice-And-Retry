using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public PauseManager pauseScreen;

	[SerializeField] private GameObject combatDataPrefab;

	[SerializeField] private Animator transition;
	private float transitionTime = 1f;

	public static bool isPause;
	public static bool isGameOver;

	public string mainScene;
	public string combatScene = "Combat";


	/* Singleton */
	public static GameManager instance;

	void Awake()
	{
		/* Singleton */
		//if (instance != null)
		//{
		//    Debug.LogError("Plus d'une instance GameManager existe!");
		//    return;
		//}
		instance = this;
		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(transition.gameObject);
		DontDestroyOnLoad(pauseScreen.transform.parent.gameObject);
		SceneManager.LoadScene(combatScene, LoadSceneMode.Additive);
		mainScene = SceneManager.GetActiveScene().name;
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
		fightData.enemyData = enemy.enemyData;
		Destroy(enemy.gameObject);

		//transition.gameObject.SetActive(true);
		//StartCoroutine(StartGame("Combat"));
		StartCoroutine(SetActiveScene(false));
		Debug.Log(Player.instence.dice.Count);
	}

	public void LoadMainScene()
	{
		Debug.Log("Return to main");
		StartCoroutine(SetActiveScene(true));

		Destroy(FightData.instance.gameObject);
	}

	private IEnumerator SetActiveScene(bool activeMain)
	{
		if (transition != null)
		{
			transition.gameObject.SetActive(true);
			transition.SetTrigger("End");
		}

		yield return new WaitForSeconds(transitionTime);

		foreach (GameObject _GO in SceneManager.GetSceneByName(activeMain ? mainScene : combatScene).GetRootGameObjects())
			_GO.SetActive(true);

		foreach (GameObject _GO in SceneManager.GetSceneByName(!activeMain ? mainScene : combatScene).GetRootGameObjects())
			_GO.SetActive(false);

		if (transition != null)
			transition.gameObject.SetActive(false);
	}
}
