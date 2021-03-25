using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float enemyKnockback = 5;
    public float batDamage = 1;
    public float ratDamage = 2;
    public float heroHealth = 10;
    public float heroSpeed = 5;
    public float heroJumpForce = 10;
    public Color heroDMGColour;
    public Image UIhealthBar;
    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        UIhealthBar.fillAmount = heroHealth / 10;
    }
}
