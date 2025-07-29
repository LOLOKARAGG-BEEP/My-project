using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOutro : MonoBehaviour
{
    public string nextLevelIntroScene = "Level2IntroScene"; 

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelIntroScene);
    }
}
//