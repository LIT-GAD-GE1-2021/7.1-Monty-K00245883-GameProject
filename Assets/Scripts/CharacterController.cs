using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private float groundRadius = 0.3f;
    private float headRadius = 0.3f;
    private float move;
    private bool duck;
    private bool dead = false;
    private bool knockingBack = false;
    public bool isGrounded;
    public bool facingRight;
    public bool onOil = false;
    public Rigidbody2D heroRB;
    public GameObject hero;
    private Animator heroAnimator;
    private SpriteRenderer heroSR;
    public LayerMask whatIsGround;
    private Transform heroPivot;
    public Transform groundCheck;
    public Transform headCheck;
    public Animator fxAnimator;

    void Start()
    {
        heroAnimator = hero.GetComponent<Animator>();
        heroPivot = hero.GetComponent<Transform>();
        heroSR = hero.GetComponent<SpriteRenderer>();
        facingRight = true;
    }
    void Update()
    {
        //the controller will only accept input under certain conditions:
        if (LevelManager.isPaused == false && knockingBack == false && dead == false && onOil == false)
        {
            MoveLeftRight();
            Jump();
            Duck();
            StartCoroutine(Action());
            if (LevelManager.instance.heroHealth <= 0)
            {
                StartCoroutine(KillHero());
            }
        }
        OilSlide();
        InventoryCheck();
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
    void OilSlide()
    {
        if (onOil)
        {
            if (facingRight)
            {
                //this is the same as the movement script but the input has been removed
                //the character will keep moving in their starting direction until they've slid off the oil
                heroRB.velocity = new Vector2(LevelManager.instance.oilSpeed, heroRB.velocity.y);
            }
            else
            {
                //because the move input has been removed, the code needs to manually check which direction
                //the character is facing and move accordingly
                heroRB.velocity = new Vector2(-LevelManager.instance.oilSpeed, heroRB.velocity.y);
            }
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

    IEnumerator Action()
    {
        if (Input.GetButtonDown("Fire1") && LevelManager.instance.hasPick)
        {
            if (isGrounded)
            {
                heroAnimator.SetBool("Attack", true);
                fxAnimator.SetTrigger("attackFX");
                yield return new WaitForSeconds(.5f);
                heroAnimator.SetBool("Attack", false);
            }

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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (LevelManager.isPaused == false && dead == false)
            {
                //this checks if the character has collided with the main collider of the enemy, which is the polygon collider
                if (collision.gameObject.tag == "Enemy" && collision.collider is PolygonCollider2D)
                {
                    StartCoroutine(DamageHero());
                    if (collision.gameObject.name == "Rat" | collision.gameObject.name == "PlatformRat")
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
                if (collision.gameObject.name == "Spikes")
                 {
                     StartCoroutine(DamageHero());
                     LevelManager.instance.heroHealth -= LevelManager.instance.spikeDamage;
                     Debug.Log(LevelManager.instance.heroHealth);
                 }
                if (collision.gameObject.name == "SlipperyFloors")
                 {
                    onOil = true;
                 }
                else
                {
                    onOil = false;
                }
            }      
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "SlipperyFloors")
        {
            onOil = false;
        }
    }
    void InventoryCheck()
    {
        if (LevelManager.instance.hasPick)
        {
            heroAnimator.SetBool("Pick", true);
        }
        else
        {
            heroAnimator.SetBool("Pick", false);
        }
    }
    IEnumerator KillHero()
    {
        heroAnimator.SetTrigger("Die");
        dead = true;
        yield return new WaitForSeconds(1f);
        LevelManager.instance.PauseUnpause();
        //activate main menu
    }
    IEnumerator DamageHero()
        {
            knockingBack = true;
            heroSR.color = LevelManager.instance.heroDMGColour;
            if (facingRight)
            {
                heroRB.velocity = new Vector2(LevelManager.instance.enemyHKnockback, -LevelManager.instance.enemyVKnockback);
            }
            else
            {
                heroRB.velocity = new Vector2(LevelManager.instance.enemyHKnockback, LevelManager.instance.enemyVKnockback);
            }
            Debug.Log("knocked back");
            yield return new WaitForSeconds(0.5f);
            heroSR.color = new Color(1, 1, 1, 1);
            knockingBack = false;
        }
}

