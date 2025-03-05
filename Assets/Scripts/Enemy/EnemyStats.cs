using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float health = 50f; // Düşmanın toplam canı
    [SerializeField]
    private Enemy enemyScript;
    [SerializeField]
    private Animator animator;

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage, remaining health: {health}");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        enemyScript.enabled = false;
        animator.SetTrigger("Die"); // Ölüm animasyonunu başlat
        gameObject.layer = LayerMask.NameToLayer("Dead"); // Layer'ı değiştir

        Debug.Log($"{gameObject.name} has died!");
        Invoke(nameof(DestroyEnemy), 3f); // Belirli süre sonra yok et
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
