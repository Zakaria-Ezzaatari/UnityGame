using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public float speed = 0.5f;
    Rigidbody2D rb2d;
    Animator animator;

    SpriteRenderer spriteRenderer;

    
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = new Vector2 (speed * (-1), rb2d.velocity.y);
        animator.Play("Enemy1Run");
    }

    private void OnCollisionEnter(Collision other) 
    {
        spriteRenderer.flipX = rb2d.velocity.x <0;
        
        
    }
}
