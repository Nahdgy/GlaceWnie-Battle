
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

public class StartMenu : MonoBehaviour
{
    public GameObject gameOverUI;
    [SerializeField]
    public static StartMenu instance;

    private void Awake()
    {
        instance = this;
    }
    public void ChangeScene(String _scenename)
    {
        SceneManager.LoadScene(_scenename);
    }

    public void SettingsButton()
    {
        if (Input.GetButtonDown("Start"))
        {
            GetComponentInChildren<Button>().onClick.Invoke();
        }
    }


    public void QuitMainMenu()
    {
        Application.Quit();
    }
    public void RetryGameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverUI.SetActive(false);
    }
    public void StartMenuGameOver()
    {

    }
    public void QuitGameOver()
    {
        Application.Quit();
    }

    
    public void VanillaGameEnd()
    {
        gameOverUI.SetActive(true);
    }

    public void Update()
    {
        SettingsButton();
    }
}
