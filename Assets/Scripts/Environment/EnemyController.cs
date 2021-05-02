using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemyHealth;
    private bool facingRight;
    public float enemySpeed;
    private Rigidbody2D enemyRB;
    void Start()
    {
        enemyRB = this.GetComponent<Rigidbody2D>();

        OrientEnemy();
        AssignHealth();
        Patrol();
    }
    void Update()
    {
        if (enemyHealth <= 0)
        {
             KillEnemy();
        }

    }
    private void FixedUpdate()
    {
        if (facingRight)
        {
            enemyRB.velocity = Vector2.right * enemySpeed;
        }
        else
        {
            enemyRB.velocity = Vector2.left * enemySpeed;
        }
    }
    void Patrol()
    {

    }

    void AssignHealth()
    {
        if (this.gameObject.name == "PlatformRat" | this.gameObject.name == "Rat")
        {
            enemyHealth = LevelManager.instance.ratHealth;
        }
        if (this.gameObject.name == "Bat")
        {
            enemyHealth = LevelManager.instance.batHealth;
        }
    }
    void OrientEnemy()
    {
        Transform enemyPivot = this.GetComponent<Transform>();
        Vector3 startingDirection = enemyPivot.transform.localScale;
        if (startingDirection.x == 1)
        {
            facingRight = false;
        }
        else
        {
            facingRight = true;
        }

    }
    void KillEnemy()
    {
        Animator enemyAnimator = this.GetComponent<Animator>();
        Debug.Log("Enemy killed");
        enemyAnimator.SetBool("Die", true);
    }
    public void DestroyEnemy()
    {
        GameObject enemy = this.gameObject;
        Destroy(enemy);
    }
    IEnumerator DamageEnemy()
    {
        SpriteRenderer enemySR = this.GetComponent<SpriteRenderer>();
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Flip();
        }
        //checks if the character's hitbox has collided with the enemy
        if (collision.collider is BoxCollider2D && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DamageEnemy());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log(this.gameObject.name + " has collided with a wall");
            Flip();
        }
    }

    void Flip()
   {
        facingRight = !facingRight;
        Transform enemyPivot = this.GetComponent<Transform>();
        Vector3 theScale = enemyPivot.transform.localScale;
        theScale.x *= -1;
        enemyPivot.transform.localScale = theScale;
        Patrol();
   }

}
