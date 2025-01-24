using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Karakterin hareket hızı
    public VariableJoystick variableJoystick; // Joystick referansı

    private Vector2 movement;  // Hareket yönü vektörü
    private Rigidbody2D rb;
    private Animator animator; // Animator referansı

    [Header("Camera Settings")]
    public Camera mainCamera;  // Takip eden kamera
    public Vector3 cameraOffset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Animator bileşenini al
    }

    void Update()
    {
        // Joystick'ten gelen girdi değerlerini al
        movement.x = variableJoystick.Horizontal;
        movement.y = variableJoystick.Vertical;

        // Animasyonu ayarla: karakter hareket ediyorsa "isWalking" true olsun
        bool isWalking = movement != Vector2.zero;
        animator.SetBool("isWalking", isWalking);
    }

    void FixedUpdate()
    {
        // Hareketi uygula
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Sağa/sola hareket ediyorsa karakteri döndür
        if (movement.x != 0)
        {
            float angle = movement.x > 0 ? 0f : 180f;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        // Kamerayı takip ettir
        if (mainCamera != null)
        {
            Vector3 targetPosition = transform.position + cameraOffset;
            mainCamera.transform.position = targetPosition;
        }
    }
}
