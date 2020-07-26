using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class ChoiceScript : CloseErrorScript
{
    public Text text;

    public override void CloseGameObj()
    {
        GameObj.SetActive(true);
    }

    public void ClickRemove()
    {
        string file_info = Application.dataPath + "/info.txt";
        string file_names = Application.dataPath + "/names.txt";

        StreamReader sri = new StreamReader(file_info);
        StreamReader srn = new StreamReader(file_names);

        string line;
        string name;

        string first_name = text.text.ToString();

        int i=0, k=0;

        //////new Dates///////
        while ((line = sri.ReadLine()).StartsWith(first_name + ";")==false)
        {
            i++;
        }
        sri.Close();

        while ((name = srn.ReadLine()).StartsWith(first_name)==false)
        {
            k++;
        }
        srn.Close();
        ///////new Dates///////

        string[] readInfo = System.IO.File.ReadAllLines(file_info);
        using (System.IO.StreamWriter fileI = new System.IO.StreamWriter(file_info, false))
        {
            for (int j = 0; j < readInfo.Length; j++)
            {
                if (j != i)
                    fileI.WriteLine(readInfo[j]);
            }
            fileI.Close();
        }

        string[] readNames = System.IO.File.ReadAllLines(file_names);
        using (System.IO.StreamWriter fileN = new System.IO.StreamWriter(file_names, false))
        {
            for (int j = 0; j < readNames.Length; j++)
            {
                if (j != k)
                    fileN.WriteLine(readNames[j]);
            }
            fileN.Close();
        }

        SceneManager.LoadScene("main");
    }
}
