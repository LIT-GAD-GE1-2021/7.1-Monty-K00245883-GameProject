using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnimator;
    public GameObject connectedSwitch;
    private SwitchController switchControl;
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        switchControl = connectedSwitch.GetComponent<SwitchController>();
    }

    void Update()
    {
        doorAnimator.SetBool("Open", switchControl.switchFlipped);
    }
}
