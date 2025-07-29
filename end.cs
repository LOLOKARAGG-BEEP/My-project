using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndManager : MonoBehaviour
{
    public string outroSceneName = "Level1OutroScene";
    public PauseManager pauseManager; 
    private bool playerIsDead = false;
    private bool outroShown = false;

    void Update()
    {
        if (playerIsDead || outroShown) return;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            outroShown = true;
            SceneManager.LoadScene(outroSceneName);
        }
    }

    public void OnPlayerDeath()
    {
        if (playerIsDead) return;

        playerIsDead = true;
        Time.timeScale = 0f;
        if (pauseManager != null)
        {
            pauseManager.ShowPauseMenu(); 
        }
    }
}
//