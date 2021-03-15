using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableWall : MonoBehaviour
{
    [Tooltip("The speed the player climbs at")]
    public float climbSpeed;
    [Tooltip("The point from which a ray will be cast to find a wall")]
    public Transform rayCheckOrigin;
    [Tooltip("The length of the ray")]
    public float rayLength;
    public LayerMask wallsLayer;
    public float wallJumpForce;

    private bool atWall;

    private float vAxis;
    private float hAxis;
    public GameObject hero;
    private Rigidbody2D theRigidBody;
    private CharacterController player;
    private Animator theAnimator;

    void Start()
    {
        theRigidBody = hero.GetComponent<Rigidbody2D>();
        theAnimator = hero.GetComponent<Animator>();
        player = hero.GetComponent<CharacterController>();
    }

    void Update()
    {
        vAxis = Input.GetAxis("Vertical");
        hAxis = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        WallHitCheck();
        if (vAxis > 0 && atWall)
        {
            theRigidBody.velocity = Vector2.up * climbSpeed;
        }
        if (theRigidBody.velocity.y > 0 && atWall)
        {
            theAnimator.SetBool("Climbing", true);
        }
        else
        {
            theAnimator.SetBool("Climbing", false);
        }

        if (atWall && !player.isGrounded && hAxis != 0)
        {
            if (hAxis < 0 && player.facingRight)
            {
                player.Flip();
                theRigidBody.AddForce(new Vector2(-1, 1) * wallJumpForce, ForceMode2D.Impulse);
            }

            if (hAxis > 0 && !player.facingRight)
            {
                player.Flip();
                theRigidBody.AddForce(new Vector2(1, 1) * wallJumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void WallHitCheck()
    {
        RaycastHit2D rayHit;

        if (player.facingRight)
        {
            rayHit = Physics2D.Raycast(rayCheckOrigin.position, Vector2.right, rayLength, wallsLayer);
            Debug.DrawRay(rayCheckOrigin.position, Vector2.right * rayLength, Color.green);
        }
        else
        {
            rayHit = Physics2D.Raycast(rayCheckOrigin.position, Vector2.left, rayLength, wallsLayer);
            Debug.DrawRay(rayCheckOrigin.position, Vector2.left * rayLength, Color.green);
        }

        if (rayHit.collider != null)
        {
            this.atWall = true;
        }
        else
        {
            this.atWall = false;
        }
    }
}

