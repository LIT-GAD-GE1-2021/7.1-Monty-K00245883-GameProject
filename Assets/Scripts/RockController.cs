using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    private ParticleSystem particleEmitter;
    private GameObject theRock;
    private Animator rockAnimator;
    void Start()
    {
        theRock = this.gameObject;
        rockAnimator = GetComponent<Animator>();
        particleEmitter = GetComponent<ParticleSystem>();
        particleEmitter.Stop();
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        particleEmitter.Play();
        rockAnimator.SetBool("Die", true);
    }
    public void DestroyRock()
    {
        Destroy(theRock);
    }
}
