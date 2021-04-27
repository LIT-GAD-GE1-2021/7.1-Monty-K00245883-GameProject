using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitHandler : MonoBehaviour
{
    private Animator portraitAnimator;
    void Start()
    {
        portraitAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AnimatePortrait()
    {
        portraitAnimator.SetBool("Activated", true);
    }
}
