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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.name != "PlatformRat")
        {
            Debug.Log("bat or rat has collided with a wall");
            Flip();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (this.gameObject.name == "PlatformRat")
        {
            Debug.Log("platformrat reached the edge of a ledge");
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
