


using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public int enemiesPerWave = 10;
    public string outroSceneName = "Level1OutroScene";

    private int enemiesRemaining;
    private bool playerIsDead = false;
    private bool outroLoaded = false;

    void Start()
    {
        enemiesRemaining = enemiesPerWave;
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        UIManager.Instance?.UpdateWaveNumber(1);

        for (int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0 || spawnPoints.Length == 0) return;

        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject enemy = Instantiate(prefab, spawnPoint.position, Quaternion.Euler(100f, 0, -0));
        enemy.tag = "Enemy";
    }

    public void OnEnemyKilled()
    {
        if (playerIsDead || outroLoaded) return;

        enemiesRemaining--;

        if (enemiesRemaining <= 0)
        {
            Invoke("LoadOutro", 1f);
        }
    }

    public void OnPlayerDeath()
    {
        playerIsDead = true;
    }

    void LoadOutro()
    {
        if (!playerIsDead && !outroLoaded)
        {
            outroLoaded = true;
            SceneManager.LoadScene(outroSceneName);
        }
    }
}
//