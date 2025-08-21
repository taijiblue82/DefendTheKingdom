using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // 적 프리팹
    public float spawnInterval = 2f; // 몇 초마다 생성할지

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(8, 0, 0); // 오른쪽 화면 바깥
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}