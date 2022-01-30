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
    public int maxHealth;
    [SerializeField]
    private Sprite heart;
    [SerializeField]
    private Sprite heartEmpty;
    [SerializeField]
    private Image[] hearts;

    private GameObject normalWorldScene;
    private GameObject ghostWorldScene;
    private PlayerSpriteHandler psHandler;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;

    private bool isGrounded;
    private float moveSpeed;
    private float jumpForce;
    private bool man;
    private void Start()
    {
        man = true;
        normalWorldScene = GameObject.Find("NormalWorld");
        ghostWorldScene = GameObject.Find("GhostWorld");

        psHandler = gameObject.GetComponent<PlayerSpriteHandler>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        normalWorldScene.SetActive(true);
        ghostWorldScene.SetActive(false);

        maxHealth = 3;
        health = maxHealth;

        jumpForce = 9f;
        moveSpeed = 1200;

        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        animator.SetFloat("SpeedAnim", Mathf.Abs(rb.velocity.x));
        animator.SetBool("OnGround", isGrounded);
        animator.SetBool("Man", man);

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
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (normalWorldScene.activeSelf)
            {
                ChangeWorld(1);
            }
            else if (!normalWorldScene.activeSelf)
            {
                ChangeWorld(0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    private void Movement()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(horizontal * moveSpeed * Time.deltaTime, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
           
            if (man is true)
            {
                spriteRenderer.flipX = true;
            }
            else if (man is false)
            {
                spriteRenderer.flipX = false;
            }



        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            
            if (man is true)
            {
                spriteRenderer.flipX = false;
            }
            else if (man is false)
            {
                spriteRenderer.flipX = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(0, jumpForce);
        }
    }
    public void ChangeWorld(int w)
    {
        if (w.Equals(0))
        {
            psHandler.ChangeSprite(psHandler.normalSprite, "Normal");
            normalWorldScene.SetActive(true);
            ghostWorldScene.SetActive(false);
            man = true;
        }
        if (w.Equals(1))
        {
            psHandler.ChangeSprite(psHandler.ghostSprite, "Ghost");
            normalWorldScene.SetActive(false);
            ghostWorldScene.SetActive(true);
            man = false;
        }
    }
    public void Damage(int amount)
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
