using UnityEngine;
using UnityEngine.SceneManagement; // 씬 리로드용

public class Castle : MonoBehaviour
{
    public int maxHealth = 10;   // 성 최대 체력
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Castle HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("게임 오버! 성이 파괴됨!");
        // 간단히 현재 씬 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}