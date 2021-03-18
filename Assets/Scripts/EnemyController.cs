using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D enemyRB;
    private bool facingRight;
    private Transform enemyPivot;
    private Vector3 startingDirection;
    public float enemySpeed;
    void Start()
    {
        enemyPivot = this.GetComponent<Transform>();
        facingRight = false;
    }
    void Update()
    {
        Patrol();

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
    /**
   private void OnCollisionEnter2D(Collision2D collision)
   {
       if (collision.gameObject.tag == "Wall")
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
  **/
}
