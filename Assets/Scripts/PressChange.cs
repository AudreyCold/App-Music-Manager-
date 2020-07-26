using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class PressChange : ButtonScript
{
    public InputField Name_if, Year_if, Names_if, Place_if, Repertoire_if, Cities_if;

    protected string first_name;
    protected string first_place;

    void Awake()
    {
        generated();
    }

    public override void press(string name)
    {
        string ln;
        string[] split;

        string file_info = Application.dataPath + "/info.txt";
        string file_names = Application.dataPath + "/names.txt";

        AllGroups.SetActive(false);

        using (StreamReader sc = new StreamReader(file_info))
        {
            while ((ln = sc.ReadLine()) != null)
            {
                if (ln.StartsWith(name + ";") == true)
                {
                    split = ln.Split(new char[] { ';' });

                    Name_if.text = first_name = split[0];
                    Year_if.text = split[1];
                    Names_if.text = split[2];
                    Repertoire_if.text = split[3];
                    Cities_if.text = split[4];
                    Place_if.text = first_place = split[5];

                    break;
                }
            }
            sc.Close();
        }
    }
}
