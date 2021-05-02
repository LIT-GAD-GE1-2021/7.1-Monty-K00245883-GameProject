using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RotatePlatform()
    {
        Transform platformTransform = this.GetComponent<Transform>();
        platformTransform.Rotate(0, 0, 90);
    }
}
