using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public GameObject archerPrefab;  // 소환할 유닛
    public Transform spawnPoint;     // 배치 위치
    public int archerCost = 50;      // 유닛 가격

    public void SpawnArcher()
    {
        if (GameManager.Instance.SpendGold(archerCost))
        {
            Instantiate(archerPrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log("Archer Spawned!");
        }
        else
        {
            Debug.Log("Not enough gold!");
        }
    }
}