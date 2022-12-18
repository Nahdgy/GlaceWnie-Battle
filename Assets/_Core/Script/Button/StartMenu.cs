
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private GameObject winUI;
    [SerializeField]
    private GameObject lastEnnemy;

    [SerializeField]
    public int timer;

    [SerializeField]
    public static StartMenu instance;
    [SerializeField]
    private List<EnemyController> boss = new List<EnemyController>();
    [SerializeField]
    private string Winning_Scene;
    public EnemyController chris_brownie { get; private set; }

    private void Start()
    {
        chris_brownie = lastEnnemy.GetComponent<EnemyController>();
    }
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
    public void Win(String _scenename)
    {
        boss = FindObjectsOfType<EnemyController>().ToList();
        if (boss.Count == 0)
        {
            SceneManager.LoadScene(_scenename);
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
    public void StartMenuGameOver(string _scenename)
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
        Win(Winning_Scene);
    }
}
