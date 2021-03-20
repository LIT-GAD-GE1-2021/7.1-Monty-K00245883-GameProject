using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    private float groundRadius = 0.3f;
    private float headRadius = 0.3f;
    private float move;
    private bool duck;
    public bool isGrounded;
    public bool facingRight;
    public Rigidbody2D heroRB;
    public GameObject hero;
    private Animator heroAnimator;
    public LayerMask whatIsGround;
    private Transform heroPivot;
    public Transform groundCheck;
    public Transform headCheck;


    void Start()
    {
        heroAnimator = hero.GetComponent<Animator>();
        heroPivot = hero.GetComponent<Transform>();
        facingRight = true;
    }
    void Update()
    {
        MoveLeftRight();
        Jump();
        Duck();
        GroundCheck();
        HeadCheck();
    }
    public void MoveLeftRight()
    {
        move = Input.GetAxis("Horizontal");
        heroAnimator.SetFloat("Speed", Mathf.Abs(move));
        heroRB.velocity = new Vector2(move * LevelManager.instance.heroSpeed, heroRB.velocity.y);
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }
    void Jump()
    {
        heroAnimator.SetFloat("VSpeed", heroRB.velocity.y);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            heroAnimator.SetBool("Ground", isGrounded);
            heroRB.velocity = new Vector2(heroRB.velocity.x, LevelManager.instance.heroJumpForce);
        }
    }
    void Duck()
    {
        duck = Input.GetButton("Fire3");

        if (duck == true)
        {
            heroAnimator.SetBool("Duck", true);
        }
        else if (duck == false)
        {
            heroAnimator.SetBool("Duck", false);
        }
    }
    void GroundCheck()
    {
        Collider2D colliderWeCollidedWith = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        isGrounded = (bool)colliderWeCollidedWith;
        heroAnimator.SetBool("Ground", isGrounded);
    }
    void HeadCheck()
    {
        Collider2D colliderWeCollidedWith = Physics2D.OverlapCircle(headCheck.position, headRadius, whatIsGround);
    }
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = heroPivot.transform.localScale;
        theScale.x *= -1;
        heroPivot.transform.localScale = theScale;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            heroAnimator.SetTrigger("Damage");
            heroRB.AddRelativeForce(LevelManager.instance.enemyKnockback);
        }
    }
}

