using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public bool switchFlipped;
    public GameObject connectedObject;
    public bool isSpawnerSwitch;


    // Start is called before the first frame update
    void Start()
    {
        switchFlipped = false;


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
        Animator switchAnimator = this.GetComponent<Animator>();
        ItemSpawner spawnControl = connectedObject.GetComponent<ItemSpawner>();
        switchFlipped = !switchFlipped;
        switchAnimator.SetBool("Up", switchFlipped);
        LevelManager.instance.DingSound();
        if (isSpawnerSwitch)
        {
            spawnControl.SpawnOnSwitch();
        }
    }
   
}      