using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public bool switchFlipped;
    private Animator switchAnimator;
    // Start is called before the first frame update
    void Start()
    {
        switchFlipped = false;
        switchAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetButtonDown("Fire1"))
        {
            FlipSwitch();
        }
    }
    public void FlipSwitch()
    {
        Debug.Log("Switch flipped");
        switchFlipped = !switchFlipped;
        switchAnimator.SetBool("Up", switchFlipped);
    }
}
