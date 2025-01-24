using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSpeel : MonoBehaviour
{
    public float damage = 10f; // Verilecek hasar
    public float lifetime = 3f; // Merminin yok olma süresi

    void Start()
    {
        // Mermiyi belirli bir süre sonra yok et
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BasicEnemy"))
        {
            // Düşmanın TakeDamage fonksiyonunu çağır
            EnemyStats enemy = collision.GetComponent<EnemyStats>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Mermiyi yok et
            Destroy(gameObject);
        }
    }
}