using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject startMenu;
    public GameObject settingsMenu;
    public GameObject pauseMenu;
    public GameObject resultScreen;
    public Text scoreText;
    public Text waveText;
    public Text missileText;

    private int score = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void UpdateScore(int amount)
    {
        score += amount;
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public void UpdateWaveNumber(int wave)
    {
        if (waveText != null)
            waveText.text = "Wave: " + wave;
    }

    public void UpdateMissileCount(int count)
    {//
        if (missileText != null)
            missileText.text = "Missiles: " + count;
    }

    public void ShowResults()
    {
        if (resultScreen != null)
        {
            resultScreen.SetActive(true);
            Text resultText = resultScreen.GetComponentInChildren<Text>();
            if (resultText != null)
                resultText.text = "Final Score: " + score;
        }
    }

    public void StartGame()
    {
        if (startMenu != null)
            startMenu.SetActive(false);
    }

    public void ToggleSettings()
    {
        if (settingsMenu != null)
            settingsMenu.SetActive(!settingsMenu.activeSelf);
    }

    public void TogglePause()
    {
        if (pauseMenu != null)
        {
            bool isPaused = !pauseMenu.activeSelf;
            pauseMenu.SetActive(isPaused);
            Time.timeScale = isPaused ? 0 : 1;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}