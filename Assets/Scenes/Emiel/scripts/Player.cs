using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;

    private int health;
    private int maxHealth;
    [SerializeField]
    private Sprite heart;
    [SerializeField]
    private Sprite heartEmpty;
    [SerializeField]
    private Image[] hearts;

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
        maxHealth = 3;
        health = maxHealth;

        jumpForce = 7.5f;
        moveSpeed = 1200;

        activePlayerSprite = GetComponentInChildren<SpriteRenderer>().sprite = ghostSprite;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        animator.SetFloat("SpeedAnim", Mathf.Abs(rb.velocity.x));
        animator.SetBool("OnGround", isGrounded);
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = heart;
            }
            else
            {
                hearts[i].sprite = heartEmpty;
            }
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        Movement();
    }
    private void Movement()
    {
        Debug.Log("Movementspeed" + rb.velocity.x);
        Debug.Log("Jump" + isGrounded);
        float horizontal = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(horizontal * moveSpeed * Time.deltaTime, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<SpriteRenderer>().flipX = false;
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
    private void Damage(int amount)
    {
        if (health > 0)
        {
            health -= amount;
            if (health <= 0)
            {
                SceneManager.LoadScene("EndScreen");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            Damage(1);
            Debug.Log(health);
        }
    }
}
