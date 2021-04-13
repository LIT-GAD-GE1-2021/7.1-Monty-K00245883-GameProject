using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private Animator pickAnimator;
    private Animator ropeAnimator;
    public GameObject pick;
    public GameObject rope;
    void Start()
    {
        pickAnimator = pick.GetComponent<Animator>();
        ropeAnimator = rope.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Pick")
        {
            LevelManager.instance.hasPick = true;
            pickAnimator.SetBool("PickGet", true);
        }

        if (collision.gameObject.name == "Rope")
        {
            LevelManager.instance.hasRope = true;
            ropeAnimator.SetBool("RopeGet", true);
        }
    }
    //this is called in the pickget/ropeget animation
    void DestroyItem()
    {
        Destroy(this);
    }
}
