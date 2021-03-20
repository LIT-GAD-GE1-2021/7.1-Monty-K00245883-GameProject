using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Vector2 enemyKnockback;
    public float batDamage = 1;
    public float ratDamage = 2;
    public float heroHealth = 10;
    public float heroSpeed = 5;
    public float heroJumpForce = 10;
    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        
    }
}
