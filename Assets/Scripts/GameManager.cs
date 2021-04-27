using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int activeSceneIndex = 0;


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

    }
    void Update()
    {

    }

    public void LoadNextScene()
    {
        Debug.Log("Continuing...");
        activeSceneIndex++;

        activeSceneIndex = activeSceneIndex % SceneManager.sceneCountInBuildSettings;

        SceneManager.LoadScene(activeSceneIndex);
    }
    public void StartNewGame()
    {
        Debug.Log("Starting new game...");
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
