using UnityEngine;
public class PlayerDeathHandler : MonoBehaviour
{
    public GameObject defeatMenuUI; 

    private bool isDead = false;

    public void HandleDeath()
    {
        if (isDead) return;

        isDead = true;
        Time.timeScale = 0f;

        if (defeatMenuUI != null)
        {
            defeatMenuUI.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Defeat Menu UI is not assigned!");
        }
    }
}
//