using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] GameObject settingsScreen;
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Toggle fullScreenToggle;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider soundsEffectVolumeSlider;

    private bool isFullScreen = true;
    private float music = 1;
    private float soundsEffect = 1;

    private static Dictionary<string, string> preferences = new Dictionary<string, string>();

    /* Singleton */
    public static Settings instance;

    void Awake()
    {
        /* Singleton */
        if (instance != null)
        {
            Debug.LogError("Plus d'une instance Settings existe!");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        if (SaveLoad.SaveExists("preferences"))
        {
            // Charger les preferences du joueur (sauvegarde dans un fichier local)
            preferences = SaveLoad.Load<Dictionary<string, string>>("preferences");

            isFullScreen = Utils.ConvertStringToBoolean(preferences["isFullScreen"]);
            music = Utils.ConvertStringToFloat(preferences["music"]);
            soundsEffect = Utils.ConvertStringToFloat(preferences["soundsEffect"]);
        }

        if (audioMixer != null)
        {
            audioMixer.SetFloat("Music", music);
            audioMixer.SetFloat("SoundsEffect", soundsEffect);
        }

        if (fullScreenToggle != null)
        {
            fullScreenToggle.isOn = isFullScreen;
        }

        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.value = music;
        }

        if (soundsEffectVolumeSlider != null)
        {
            soundsEffectVolumeSlider.value = soundsEffect;
        }

        Screen.fullScreen = isFullScreen;
        if (Screen.fullScreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    public void SetFullScreen(bool _isFullScreen)
    {
        Screen.fullScreen = _isFullScreen;
        isFullScreen = _isFullScreen;

        if (Screen.fullScreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    public void MusicVolume(float _volume)
    {
        audioMixer.SetFloat("Music", _volume);
        music = _volume;
    }

    public void SoundsEffectVolume(float _volume)
    {
        audioMixer.SetFloat("SoundsEffect", _volume);
        soundsEffect = _volume;
    }

    public void CloseAndSaveSettings()
    {
        SaveSettings();
        settingsScreen.SetActive(false);
    }

    public void SaveSettings()
    {
        Dictionary<string, string> newPreferences = new Dictionary<string, string>();
        newPreferences.Add("isFullScreen", isFullScreen.ToString());
        newPreferences.Add("music", music.ToString());
        newPreferences.Add("soundsEffect", soundsEffect.ToString());
        SaveLoad.Save<Dictionary<string, string>>(newPreferences, "preferences");
    }
}
