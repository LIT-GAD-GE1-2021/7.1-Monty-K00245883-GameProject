using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D heroRB;
    public GameObject hero;
    public float speed = 5;
    public float jumpForce = 5;
    public bool isGrounded;
    public bool facingRight;
    private Animator heroAnimator;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public Transform headCheck;
    private float groundRadius = 0.3f;
    private float headRadius = 0.3f;

    void Start()
    {
        heroAnimator = hero.GetComponent<Animator>();
        facingRight = false;
    }
    void Update()
    {
        MoveLeftRight();
        Jump();
        GroundCheck();
        HeadCheck();
    }
    public void MoveLeftRight()
    {
        Vector3 theScale = transform.localScale;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            heroRB.velocity = new Vector2(-speed, 0);
            theScale.x = -1;
            transform.localScale = theScale;
            facingRight = false;
            if (isGrounded == true)
            {
                heroAnimator.SetBool("isWalking", true);
            }
            else
            {
                heroRB.velocity = new Vector2(heroRB.velocity.x, -speed);
            }

        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            heroRB.velocity = new Vector2(speed, 0);
            theScale.x = 1;
            transform.localScale = theScale;
            facingRight = true;
            if (isGrounded == true)
            {
                heroAnimator.SetBool("isWalking", true);
            }
            else
            {
                heroRB.velocity = new Vector2(heroRB.velocity.x, -speed);
            }
        }
        else
        {
            heroAnimator.SetBool("isWalking", false);
        }

    }
    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded == true)
        {
            heroAnimator.SetBool("isWalking", false);
            heroAnimator.SetBool("isJumping", true);
            heroRB.velocity = new Vector2(heroRB.velocity.x, jumpForce);
        }
        else
        {
            heroAnimator.SetBool("isJumping", false);
        }
    }
    void GroundCheck()
    {
        Collider2D colliderWeCollidedWith = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        isGrounded = (bool)colliderWeCollidedWith;
    }
    void HeadCheck()
    {
        Collider2D colliderWeCollidedWith = Physics2D.OverlapCircle(headCheck.position, headRadius, whatIsGround);
    }
    public void Flip()
    {
        facingRight = !facingRight;
    }
}

