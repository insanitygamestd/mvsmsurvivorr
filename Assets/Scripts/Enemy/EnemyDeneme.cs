using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Follow Settings")]
    public Transform target;          // Takip edilecek obje
    public float followSpeed = 5f;    // Takip hızı
    public float stopDistance = 1f;   // Takibi durdurma mesafesi

    [Header("Axis Settings")]
    public bool followX = true;       // X ekseninde takip et
    public bool followY = true;       // Y ekseninde takip et
    public bool followZ = false;      // Z ekseninde takip et (2D için genelde kapalı)

    void Update()
    {
        if (target == null) return; // Eğer hedef belirlenmemişse hiçbir şey yapma

        // Hedefle bu obje arasındaki mesafeyi hesapla
        Vector3 direction = target.position - transform.position;

        // Belirli eksenleri takip etmek için kontrol
        if (!followX) direction.x = 0;
        if (!followY) direction.y = 0;
        if (!followZ) direction.z = 0;

        // Hedefe olan mesafeyi kontrol et
        if (direction.magnitude > stopDistance) // Mesafe belirli bir eşikten büyükse
        {
            // Hedefe doğru hareket et
            Vector3 moveStep = direction.normalized * followSpeed * Time.deltaTime;
            transform.position += moveStep;
           if (direction.x != 0) // X ekseninde hareket varsa
        {
            float angle = direction.x > 0 ? 0f : 180f; // Sağa hareket ediyorsa 90 derece, sola ise -90 derece
            transform.rotation = Quaternion.Euler(0, angle, 0); // Y ekseninde döner
        }
        }
    }
}