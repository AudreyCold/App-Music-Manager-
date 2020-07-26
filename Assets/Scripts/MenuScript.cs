using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Addition()
    {
        SceneManager.LoadScene("info"); 
    }

    public void ClickExit()
    {
        Application.Quit();
    }

    public void Hit()
    {
        SceneManager.LoadScene("hit");
    }

    public void BackInMenu()
    {
        SceneManager.LoadScene("main");
    }
}
