
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
    
    public void ChangeScene(String _scenename)
    { 
            SceneManager.LoadScene(_scenename);
    }

    public void SettingsButton()
    {       
    if(Input.GetButtonDown("Start"))
        {
            GetComponentInChildren<Button>().onClick.Invoke();
        }
    }

   
    public void Quit()
    {
        Application.Quit();
    }

    public void Update()
    {
        SettingsButton();
    }
}
