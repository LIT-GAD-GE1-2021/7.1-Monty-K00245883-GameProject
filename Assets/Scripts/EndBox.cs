using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndBox : MonoBehaviour
{
    public GameObject endScreen;
    // Start is called before the first frame update

    private void Awake()
    {
        endScreen.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            endScreen.SetActive(true);
        }
    }
}
