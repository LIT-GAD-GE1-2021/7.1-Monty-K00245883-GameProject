using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndBox : MonoBehaviour
{
    public GameObject endScreen;

    private void Awake()
    {
        endScreen.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelManager.instance.PauseUnpause();
            endScreen.SetActive(true);
        }
    }
}
