using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.5f;
    
    public float jumpForce = 5;

    private int coins;
    private int deaths;

    public Text CoinText;

    public Text DeathText;

    bool Grounded;

    private Vector3 OriginalPosition;

    [SerializeField]
    Transform groundCheck;

    Rigidbody2D rb2d;
    Animator animator;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        coins=0;
        deaths=0;
        CoinText.text="Coins: " + coins.ToString();
        DeathText.text="Deaths: " + deaths.ToString();
        OriginalPosition=new Vector3(-4.19f,-0.52f,0f);
    }

   
    void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position,groundCheck.position, 1 << LayerMask.NameToLayer("Platforms")))
        {
            Grounded=true;
        }
        
        else
        {
            Grounded=false;
        }

        if (Input.GetKey("d")|| Input.GetKey("right"))
        {
           rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
            if (Grounded)
            {
                animator.Play("PlayerRun");
            }
           
           spriteRenderer.flipX = false;
        }

        else if (Input.GetKey("q")|| Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2 (speed * (-1), rb2d.velocity.y);
            if (Grounded)
            {
                animator.Play("PlayerRun");
            }
            
            spriteRenderer.flipX = true;
        }

        else
        {
            if (Grounded)
            {
                animator.Play("PlayerIdle");
            }
            rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
        }
        
        if (Input.GetKey("space") && Grounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            animator.Play("PlayerJump");
            SoundManager.PlaySound("Jump");

        }
    }

    void OnTriggerEnter2D (Collider2D other)  
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            SoundManager.PlaySound("Coin");
            coins=coins+1;
            CoinText.text="Coins: " + coins.ToString();
        }

        if (other.gameObject.CompareTag("Death"))
        {
            SoundManager.PlaySound("Death");
            transform.position= OriginalPosition;
            rb2d.velocity= new Vector2(0,0);
            deaths=deaths+1;
            DeathText.text="Deaths: " + deaths.ToString();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.transform.parent.gameObject.SetActive(false);
            SoundManager.PlaySound("Stomp");
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            
        }
        
    }

}
