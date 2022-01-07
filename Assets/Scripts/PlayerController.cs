using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    public float speed;
    float xVelocity;

    public float checkRadius;
    public LayerMask platform;
    public GameObject groundCheck;
    public bool isOnGround;

    public bool playerDead;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.transform.position, checkRadius, platform);
        
        animator.SetBool("isOnGround", isOnGround);
        
        Movement();
    }

    void Movement()
    {
        // Get input for facing direction
        xVelocity = Input.GetAxisRaw("Horizontal");

        // Update the player's velocity
        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);

        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x)); // Running animation

        // if the input changes the facing direction, changes the player facing direction accordingly.
        if (xVelocity != 0)
        {
            transform.localScale = new Vector3(xVelocity, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Spike"))
        {
            animator.SetTrigger("dead");

        }
    }

    public void PlayerDead()
    {
        playerDead = true;
    }

    public void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(groundCheck.transform.position, checkRadius);    
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Fan")) 
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }
    }
}
