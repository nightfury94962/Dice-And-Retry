using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    private static MusicManager _instance;
    public static MusicManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<MusicManager>();

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

    private void Start()
    {
        audioSource.Play();
    }

    public void Stop()
    {
        if (_instance == null) return;
        if (audioSource == null) return;

        audioSource.Stop();
        Destroy(_instance.gameObject);
    }
}
