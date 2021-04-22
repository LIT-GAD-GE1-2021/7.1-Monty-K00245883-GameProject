using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public static bool isPaused;
    public bool hasPick;
    public bool hasRope;
    public float enemyVKnockback = 5;
    public float enemyHKnockback = 5;
    public float batDamage = 1;
    public float ratDamage = 2;
    public float spikeDamage = 1;
    public float heroSpeed = 5;
    public float oilSpeed = 10;
    public float heroJumpForce = 10;
    public float heroHealth = 10;
    public int coinCount = 0;
    public Color heroDMGColour;
    public Image UIHealthBar;
    public Image UIPickIcon;
    public Image UIRopeIcon;
    public Text UICoinCounter;
    public GameObject pauseScreen;
    public Button startScreenButton;
    void Awake()
    {
        instance = this;
        isPaused = true;
        pauseScreen.SetActive(false);
        heroHealth = 10;
        hasPick = false;
        hasRope = false;
    }

    void Update()
    {
        //PlayerPrefs.SetInt("Coins", coinCount);
        UICoinCounter.text = "x" + coinCount;
        UIHealthBar.fillAmount = heroHealth / 10;
        InventoryCheck();
        
        if (Input.GetKeyDown("escape")) 
        {
            PauseUnpause();
            pauseScreen.SetActive(isPaused);
        }

    }
    private void InventoryCheck()
    {
        Color invisibleColour = Color.clear;
        Color visibleColour = Color.white;
        if (hasPick)
        {
            UIPickIcon.color = visibleColour;
        }
        else
        {
            UIPickIcon.color = invisibleColour;
        }
        if (hasRope)
        {
            UIRopeIcon.color = visibleColour;
        }
        else
        {
            UIRopeIcon.color = invisibleColour;
        }
    }
    public void PauseUnpause()
    {
        isPaused = !isPaused;
        if (isPaused == false)
        {
            Debug.Log("Unpaused game");
            Time.timeScale = 1;
        }
        else
        {
            Debug.Log("Paused game");
            Time.timeScale = 0;
        }
    }
}
