using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D enemyRB;
    private Animator enemyAnimator;
    private SpriteRenderer enemySR;
    private GameObject enemy;
    public float enemyHealth;
    private bool facingRight;
    private Transform enemyPivot;
    public float enemySpeed;
    void Start()
    {
        enemyRB = this.GetComponent<Rigidbody2D>();
        enemySR = this.GetComponent<SpriteRenderer>();
        enemyAnimator = this.GetComponent<Animator>();
        enemy = this.gameObject;
        enemyAnimator.SetBool("Die", false);
        enemyPivot = this.GetComponent<Transform>();
        //determines whether the enemy is facing right or not
        Vector3 startingDirection = enemyPivot.transform.localScale;
        if (startingDirection.x == 1)
        {
            facingRight = false;
        }
        else
        {
            facingRight = true;
        }
        //sets the enemy's health according to type of enemy
        if (this.gameObject.name == "PlatformRat" | this.gameObject.name == "Rat")
        {
            enemyHealth = LevelManager.instance.ratHealth;
        }
        if (this.gameObject.name == "Bat")
        {
            enemyHealth = LevelManager.instance.batHealth;
        }
    }
    void Update()
    {
        if (LevelManager.isPaused == false)
        {
            Patrol();
        }
        if (enemyHealth <= 0)
        {
             KillEnemy();
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

    void KillEnemy()
    {
        Debug.Log("Enemy killed");
        enemyAnimator.SetBool("Die", true);
    }
    public void DestroyEnemy()
    {
        Destroy(enemy);
    }
    IEnumerator DamageEnemy()
    {
        enemyHealth -= LevelManager.instance.heroDamage;
        enemySR.color = LevelManager.instance.heroDMGColour;
        if (facingRight)
        {
            enemyRB.velocity = new Vector2(LevelManager.instance.enemyHKnockback, -LevelManager.instance.enemyVKnockback);
        }
        else
        {
            enemyRB.velocity = new Vector2(LevelManager.instance.enemyHKnockback, LevelManager.instance.enemyVKnockback);
        }
        yield return new WaitForSeconds(0.5f);
        enemySR.color = new Color(1, 1, 1, 1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checks if the character's hitbox has collided with the enemy
        if (collision.collider is BoxCollider2D && collision.gameObject.tag == "Player")
        {
            StartCoroutine(DamageEnemy());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.name != "PlatformRat" && collision.gameObject.name == "GroundMap")
        {
            Debug.Log("bat or rat has collided with a wall");
            Flip();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (this.gameObject.name == "PlatformRat" && collision.gameObject.tag == "Ground")
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
