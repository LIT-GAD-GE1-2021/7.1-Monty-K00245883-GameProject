using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitHandler : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AnimatePortrait()
    {
        Animator portraitAnimator = GetComponent<Animator>();
        portraitAnimator.SetBool("Activated", true);
    }
}
