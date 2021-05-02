using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    private ParticleSystem particleEmitter;
    void Start()
    {
        particleEmitter = GetComponent<ParticleSystem>();
        particleEmitter.Stop();
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        particleEmitter.Play();
        Animator rockAnimator = GetComponent<Animator>();
        rockAnimator.SetBool("Die", true);
    }
    public void DestroyRock()
    {
        GameObject theRock = this.gameObject;
        Destroy(theRock);
    }
}
