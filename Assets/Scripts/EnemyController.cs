using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D enemyRB;
    private bool facingRight;
    private Transform enemyPivot;
    public float enemySpeed;
    void Start()
    {
        Vector3 startingDirection;
        enemyPivot = this.GetComponent<Transform>();
        startingDirection = enemyPivot.transform.localScale;
        if (startingDirection.x == 1)
        {
            facingRight = false;
        }
        else
        {
            facingRight = true;
        }
    }
    void Update()
    {
        if (LevelManager.isPaused == false)
        {
            Patrol();
        }
    }
    void Patrol()
    {
        if (facingRight)
        {
            enemyRB.AddForce(Vector2.right * enemySpeed);
        }
        else
        {
            enemyRB.AddForce(Vector2.left * enemySpeed);
        }
    }

   private void OnCollisionEnter2D(Collision2D collision)
   {
        //the reason this checks what kind of collider is being used is because there are two colliders attached to the enemy.
        //there's a polygon collider to determine whether the character has collided and a box collider which is positioned
        //specifically on the sprite to check if the front of the enemy has hit something
        if (collision.otherCollider is BoxCollider2D)
        {
            Flip();
        }
   }
    void Flip()
   {
       facingRight = !facingRight;
       Vector3 theScale = enemyPivot.transform.localScale;
       theScale.x *= -1;
       enemyPivot.transform.localScale = theScale;
   }

}
