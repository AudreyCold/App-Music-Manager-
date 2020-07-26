using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class HotChartScript : MonoBehaviour
{
    public Text place_1, place_2, place_3;

    void Awake()
    {
        string file_info = Application.dataPath + "/info.txt";

        StreamReader sri = new StreamReader(file_info);

        string line;
        string[] Dates;

        while ((line = sri.ReadLine()) != null)
        {
            if (line.EndsWith(";1"))
            {
                Dates = line.Split(new Char[] { ';' });
                place_1.text = Dates[5] + " - " + Dates[0];
            }
            else if (line.EndsWith(";2"))
            {
                Dates = line.Split(new Char[] { ';' });
                place_2.text = Dates[5] + " - " + Dates[0];
            }
            else if (line.EndsWith(";3"))
            {
                Dates = line.Split(new Char[] { ';' });
                place_3.text = Dates[5] + " - " + Dates[0];
            }
        }
        sri.Close();
    }
}
