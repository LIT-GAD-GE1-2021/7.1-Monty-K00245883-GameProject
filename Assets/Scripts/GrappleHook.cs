using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All grapple hooks require a Collider2D component
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class GrappleHook : MonoBehaviour
{
   void Start()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
}
