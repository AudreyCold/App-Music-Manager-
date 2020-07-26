using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class MenuScript2 : MonoBehaviour
{
    public GameObject Error;

    string file;
    int i;

    void Start()
    {
        file = Application.dataPath + "/info.txt";
        Error.SetActive(false);

        using (StreamReader sr = new StreamReader(file))
        {
            i = System.IO.File.ReadAllLines(file).Length;
            sr.Close();
        }
        
    }

    public void GetInfo()
    {
        if (i == 0)
            Error.SetActive(true);
        else
            SceneManager.LoadScene("all_groups");
    }

    public void ChangeInfo()
    {

        if (i == 0)
            Error.SetActive(true);
        else
            SceneManager.LoadScene("change");
    }

    public void RemoveInfo()
    {
        if (i == 0)
            Error.SetActive(true);
        else
            SceneManager.LoadScene("remove");
    }
}
