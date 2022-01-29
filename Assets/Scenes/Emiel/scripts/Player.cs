using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private Sprite activePlayerSprite;
    public Sprite ghostSprite;
    public Sprite normalSprite;

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;

    private bool isGrounded;
    private float moveSpeed;
    private void Start()
    {
        moveSpeed = 1000;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        Movement();
    }
    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * moveSpeed * Time.deltaTime, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(0, 5f);
        }
    }
    public void ChangeSprite(Sprite newPlayerSprite)
    {
        activePlayerSprite = newPlayerSprite;
    }
}
