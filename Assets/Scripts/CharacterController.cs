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
    private SpriteRenderer heroSR;
    public LayerMask whatIsGround;
    private Transform heroPivot;
    public Transform groundCheck;
    public Transform headCheck;


    void Start()
    {
        heroAnimator = hero.GetComponent<Animator>();
        heroPivot = hero.GetComponent<Transform>();
        heroSR = hero.GetComponent<SpriteRenderer>();
        facingRight = true;
    }
    void Update()
    {
        if (LevelManager.isPaused == false)
        {
            MoveLeftRight();
            Jump();
            Duck();
        }

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

    IEnumerator FlashDamage()
    {
        heroSR.color = LevelManager.instance.heroDMGColour;
        yield return new WaitForSeconds(0.5f);
        heroSR.color = new Color(1, 1, 1, 1);
    }
    void KnockBack()
    {
        if (facingRight)
        {
            heroRB.AddForce(Vector2.left * LevelManager.instance.enemyKnockback, ForceMode2D.Impulse);
            Debug.Log("knocked back left");
        }
        else
        {
            heroRB.AddForce(Vector2.right * LevelManager.instance.enemyKnockback, ForceMode2D.Impulse);
            Debug.Log("knocked back right");
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && LevelManager.isPaused == false)
        {
            KnockBack();
            StartCoroutine(FlashDamage());
            if (collision.gameObject.name == "Rat")
            {
                LevelManager.instance.heroHealth -= LevelManager.instance.ratDamage;
                Debug.Log(LevelManager.instance.heroHealth);
            }
            if (collision.gameObject.name == "Bat")
            {
                LevelManager.instance.heroHealth -= LevelManager.instance.batDamage;
                Debug.Log(LevelManager.instance.heroHealth);
            }
        }
    }
}

