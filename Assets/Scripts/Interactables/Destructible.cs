using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public Animator itemAnimator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checks if the incoming collider is the hitbox of the character's attack
        if (collision.gameObject.tag == "Player" && collision.collider is BoxCollider2D)
        {
            StartCoroutine(DestroyItem());
        }
    }
    IEnumerator DestroyItem()
    {
        GameObject thisItem = this.gameObject;
        itemAnimator.SetBool("Destroy", true);
        yield return new WaitForSeconds(1f);
        Destroy(thisItem);
    }
}
