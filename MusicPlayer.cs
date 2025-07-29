using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance;
    public AudioSource musicSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        float vol = PlayerPrefs.GetFloat("MusicVolume", 1f);
        musicSource.volume = vol;
        if (!musicSource.isPlaying)
            musicSource.Play();
    }
}
//s