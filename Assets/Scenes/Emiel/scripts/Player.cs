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
    private float jumpForce;
    private void Start()
    {
        jumpForce = 7.5f;
        moveSpeed = 1200;
        activePlayerSprite = GetComponentInChildren<SpriteRenderer>().sprite = ghostSprite;
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(0, jumpForce);
        }
    }
    public void ChangeSprite(Sprite newPlayerSprite)
    {
        activePlayerSprite = newPlayerSprite;
    }
}
