using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private Animator itemAnimator;
    // Start is called before the first frame update
    void Start()
    {
        itemAnimator = this.GetComponent<Animator>();

        if (this.gameObject.name == "Coin")
        {
            itemAnimator.SetBool("isCoin", true);
        }
        else
        {
            itemAnimator.SetBool("isCoin", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            itemAnimator.SetBool("Get", true);
            if (this.gameObject.name == "Coin")
            {
                LevelManager.instance.coinCount++;
            }
            if (this.gameObject.name == "Pick")
            {
                LevelManager.instance.hasPick = true;
            }
            if (this.gameObject.name == "Rope")
            {
                LevelManager.instance.hasRope = true;
            }
        }
    }
    private void DestroyItem()
    {
        Destroy(this);
    }
}
