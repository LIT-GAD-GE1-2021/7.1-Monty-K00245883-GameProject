using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject hero;
    private Vector3 movedPosition;

    private void Start()
    {
        movedPosition = transform.position - hero.transform.position;
    }

    void LateUpdate()
    {
        transform.position = hero.transform.position + movedPosition;
    }
}
