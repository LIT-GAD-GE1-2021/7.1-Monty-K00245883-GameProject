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
    private Animator heroAnimator;

    void Start()
    {
        heroAnimator = hero.GetComponent<Animator>();
    }
    void Update()
    {
        MoveLeftRight();
        Jump();
    }
    public void MoveLeftRight()
    {
        Vector3 theScale = transform.localScale;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            heroRB.velocity = new Vector2(-speed, 0);
            theScale.x = -1;
            transform.localScale = theScale;
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
}
