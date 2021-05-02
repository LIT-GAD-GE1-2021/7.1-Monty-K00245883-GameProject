using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSwitch : MonoBehaviour
{
    public bool switchFlipped;
    void Start()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetButtonDown("Fire1"))
        {
            FlipSwitch();
            WhichSwitch();
        }
    }

    public void FlipSwitch()
    {
        Debug.Log("Switch flipped");
        switchFlipped = !switchFlipped;
        Animator switchAnimator = this.GetComponent<Animator>();
        switchAnimator.SetBool("Up", switchFlipped);
        LevelManager.instance.DingSound();
    }
    public void WhichSwitch()
    {
        if (this.gameObject.name == "PSwitchA")
        {
            PPH.instance.FlipA();
        }
        if (this.gameObject.name == "PSwitchB")
        {
            PPH.instance.FlipB();

        }
        if (this.gameObject.name == "PSwitchC")
        {
            PPH.instance.FlipC();

        }
        if (this.gameObject.name == "PSwitchD")
        {
            PPH.instance.FlipD();

        }
        if (this.gameObject.name == "PSwitchE")
        {
            PPH.instance.FlipE();

        }
    }
}
