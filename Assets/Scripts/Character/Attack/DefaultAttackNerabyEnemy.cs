using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAttackNearbyEnemy : MonoBehaviour
{
    [Header("Attack Settings")]
    public float attackRange = 5f; // Algılama menzili
    public GameObject bulletPrefab; // Fırlatılacak mermi prefabı
    public Transform firePoint; // Merminin çıkış noktası
    public float bulletSpeed = 10f; // Merminin hızı
    public LayerMask enemyLayer; // Hangi layer'daki objeler düşman olarak algılanacak
    public float attackCooldown = 1f; // Saldırı gecikmesi (saniye)

    private float lastAttackTime; // Son saldırının zamanı

    void Update()
    {
        // Düşmanları algıla ve en yakındaki düşmana mermi gönder
        DetectAndAttackClosestEnemy();
    }

    void DetectAndAttackClosestEnemy()
    {
        // Eğer cooldown aktifse saldırma
        if (Time.time - lastAttackTime < attackCooldown)
            return;

        // Oyuncu etrafındaki düşmanları algıla
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        // Eğer algılanan düşman yoksa çık
        if (enemiesInRange.Length == 0)
            return;

        // En yakındaki düşmanı bul
        Transform closestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Collider2D enemy in enemiesInRange)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                closestEnemy = enemy.transform;
            }
        }

        // En yakındaki düşmana saldır
        if (closestEnemy != null)
        {
            ShootBullet(closestEnemy);
            lastAttackTime = Time.time; // Saldırı zamanını güncelle
        }
    }

    void ShootBullet(Transform target)
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Mermiyi oluştur
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            // Mermiye hedefe doğru bir hız ver
            Vector2 direction = (target.position - firePoint.position).normalized;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed;
            }
        }
    }

    // Algılama menzilini görmek için gizmo çizelim
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
