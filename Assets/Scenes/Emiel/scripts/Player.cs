using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed;
    private Rigidbody2D rb;
    void Start()
    {
        moveSpeed = 10f;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime);
    }
}
