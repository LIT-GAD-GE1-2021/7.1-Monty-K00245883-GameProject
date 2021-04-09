using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Animator coinAnimator;
    // Start is called before the first frame update
    void Start()
    {
        coinAnimator = this.GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LevelManager.instance.coinCount++;
            coinAnimator.SetBool("CoinGet", true);
        }
    }
    private void DestroyCoin()
    {
        Destroy(this);
    }
}
