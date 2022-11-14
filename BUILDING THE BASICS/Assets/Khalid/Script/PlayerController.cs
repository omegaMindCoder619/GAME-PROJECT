using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f; 
    public InputAction playerControls;
    Vector2 move = Vector2.zero;
    public int numItems = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        move = playerControls.ReadValue<Vector2>(); 
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(move.x * moveSpeed, move.y * moveSpeed);
    }

    
}
