using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 🔹 이동 & 공격 관련
    public float speed = 2f;
    public int damage = 1;             // 성에 주는 데미지
    public float attackInterval = 1f;  // 성 공격 주기 (초 단위)

    private bool isAttacking = false;
    private Castle targetCastle;
    private float attackTimer;

    // 🔹 HP 관련
    public int maxHP = 5;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        if (!isAttacking)
        {
            // 성까지 이동
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            // 성 공격
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackInterval)
            {
                targetCastle.TakeDamage(damage);
                attackTimer = 0f;
            }
        }
    }

    // 🔹 성과 충돌 시 공격 시작
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Castle"))
        {
            isAttacking = true;
            targetCastle = collision.GetComponent<Castle>();
            attackTimer = 0f;
        }
    }

    // 🔹 수비병에게 공격 받을 때 체력 감소
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("Enemy HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 골드 드랍
        GameManager.Instance.AddGold(10); // 적 1마리당 10골드
        Destroy(gameObject);
    }
}