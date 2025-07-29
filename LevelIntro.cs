using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelIntro : MonoBehaviour
{
    public string nextSceneName = "1";

    void Start()
    {
        Invoke("LoadNextScene", 10f); 
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
