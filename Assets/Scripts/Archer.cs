using UnityEngine;

public class Archer : MonoBehaviour
{
    public float attackRange = 5f;
    public float attackInterval = 1f;
    public int damage = 1;

    private float attackTimer;

    void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackInterval)
        {
            // 범위 안의 적 탐색
            Enemy target = FindClosestEnemy();
            if (target != null)
            {
                target.TakeDamage(damage);
                Debug.Log("Archer attacked Enemy!");
                attackTimer = 0f;
            }
        }
    }

    Enemy FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        Enemy closest = null;
        float shortestDistance = attackRange;

        foreach (Enemy enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance <= shortestDistance)
            {
                shortestDistance = distance;
                closest = enemy;
            }
        }
        return closest;
    }
}