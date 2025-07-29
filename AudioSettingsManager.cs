using UnityEngine;

public class AudioSettingsManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    void Start()
    {
        float musicVol = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 1f);

        if (musicSource != null) musicSource.volume = musicVol;
        if (sfxSource != null) sfxSource.volume = sfxVol;
    }
}
//