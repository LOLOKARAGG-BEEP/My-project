using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        ApplyVolumes();

        musicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });
        sfxSlider.onValueChanged.AddListener(delegate { SetSFXVolume(); });
    }

    public void SetMusicVolume()
    {
        if (musicSource != null)
            musicSource.volume = musicSlider.value;

        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }

    public void SetSFXVolume()
    {
        if (sfxSource != null)
            sfxSource.volume = sfxSlider.value;

        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }

    private void ApplyVolumes()
    {
        if (musicSource != null)
            musicSource.volume = musicSlider.value;
        if (sfxSource != null)
            sfxSource.volume = sfxSlider.value;
    }
}
//