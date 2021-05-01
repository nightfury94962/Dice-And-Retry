using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightData : MonoBehaviour
{
	private AudioSource audioSource;

	public static FightData instance;

	public EnemyData enemyData;

	void Awake()
	{
		if (instance == null)
		{
			//If first instance, make me the Singleton
			instance = this;
			DontDestroyOnLoad(this);
		}

		audioSource = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (audioSource == null)
			return;

		if(!audioSource.isPlaying)
		{
			GameObject music = GameObject.FindGameObjectWithTag("FightMusic");
			if (music != null)
				music.GetComponent<AudioSource>().Play();
			
			Destroy();
		}
	}

	public void Setup()
	{
		if(audioSource != null)
			audioSource.PlayOneShot(audioSource.clip);


	}

	public void Destroy()
	{
		if (instance == null) return;
		if (audioSource == null) return;

		audioSource.Stop();
		Destroy(audioSource);
	}
}
