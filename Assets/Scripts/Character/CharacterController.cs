
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Karakterin hareket hızı

    
    private Vector2 movement;  // Hareket yönü vektörü

    [Header("Camera Settings")]
    public Camera mainCamera;  // Takip eden kamera
    public Vector3 cameraOffset; 
    // public float cameraSmoothSpeed = 0.125f; // Kameranın yumuşak hareketi için hız  
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
     
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        
        transform.position += new Vector3(movement.x*moveSpeed*Time.deltaTime,movement.y*moveSpeed*Time.deltaTime,0f);

         //  sağa/sola hareket ediyorsa döner
        if (movement.x != 0) // X ekseninde hareket varsa
        {
            float angle = movement.x > 0 ? 0f : 180f; // Sağa hareket ediyorsa 90 derece, sola ise -90 derece
            transform.rotation = Quaternion.Euler(0, angle, 0); // Y ekseninde döner
        }

        // camera karakteri takip etsin
        if (mainCamera != null)
        {
            Vector3 targetPosition = transform.position + cameraOffset;
            // mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, cameraSmoothSpeed);//kamerayı smooth takip için
            mainCamera.transform.position =targetPosition;
        }
    }
}