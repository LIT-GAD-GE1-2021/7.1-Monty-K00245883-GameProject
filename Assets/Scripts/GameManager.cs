using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this);
        }
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("Health") == false)
        {
            PlayerPrefs.SetInt("Health", 10);
            LevelManager.instance.heroHealth = 10;
        }
        else
        {
            LevelManager.instance.heroHealth = PlayerPrefs.GetInt("Health");
        }
    }
    void Update()
    {

    }

}
