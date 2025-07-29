using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string outroSceneName = "Level1OutroScene";

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void CheckWaveProgress()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 1) 
        {
            Invoke("LoadOutroScene", 0.5f);
        }
    }

    void LoadOutroScene()
    {
        SceneManager.LoadScene(outroSceneName);
    }
}
//