using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class PressInfo : ButtonScript
{
    public Text Name_text, Year_text, Names_text, Place_text, Repertoire_text, Cities_text;

    void Awake()
    {
        generated();
    }

    public override void press(string name)
    {
        string ln;
        string[] split;

        string file_info = Application.dataPath + "/info.txt";

        AllGroups.SetActive(false);

        using (StreamReader sl = new StreamReader(file_info))
        {
            while ((ln = sl.ReadLine()) != null)
            {
                if (ln.StartsWith(name + ";") == true)
                {
                    split = ln.Split(new char[] { ';' });

                    Name_text.text = split[0];
                    Year_text.text = split[1];
                    Names_text.text = split[2];
                    Repertoire_text.text = split[3];
                    Cities_text.text = split[4];
                    Place_text.text = split[5];

                    break;
                }
            }
            sl.Close();
        }
    }
}