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
       /** if (PlayerPrefs.HasKey("Coins") == false)
        {
            PlayerPrefs.SetInt("Coins", 0);
            LevelManager.instance.coinCount = 0;
        }
        else
        {
            LevelManager.instance.coinCount = PlayerPrefs.GetInt("Coins");
        }
       **/
    }
    void Update()
    {

    }

}
