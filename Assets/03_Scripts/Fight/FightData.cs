using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightData : MonoBehaviour
{
    private AudioSource audioSource;

    private static FightData _instance;
    public static FightData instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<FightData>();

                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            //If first instance, make me the Singleton
            _instance = this;
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
        if (_instance == null) return;
        if (audioSource == null) return;

        audioSource.Stop();
        Destroy(audioSource);
    }
}
