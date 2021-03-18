using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D enemyRB;
    private bool facingRight;
    private Transform enemyPivot;
    private Vector3 startingDirection;
    public float enemySpeed;
    void Start()
    {
        enemyRB = this.GetComponent<Rigidbody2D>();
        enemyPivot = this.GetComponent<Transform>();
        //this checks whether the enemy starts off facing right in the scene or not
        enemyPivot.transform.localScale = startingDirection;
        if (startingDirection.x == -1)
        {
            facingRight = true;
        }
        else
        {
            facingRight = false;
        }
        Patrol();
    }
    void Update()
    {

    }
    void Patrol()
    {
        enemyRB.velocity = new Vector2(enemySpeed, enemyRB.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Flip();
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = enemyPivot.transform.localScale;
        theScale.x *= -1;
        enemyPivot.transform.localScale = theScale;
    }
}
