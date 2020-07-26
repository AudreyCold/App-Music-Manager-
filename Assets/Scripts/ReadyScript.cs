using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class ReadyScript : MonoBehaviour
{
    public InputField Name, Year, Structure, Place, Repertoire, Cities;

    public GameObject Error;
    public Text text;

    string textN, textY, textS, textP, textR, textC;

    public ReadyScript()
    {
        textN = null;
        textY = null;
        textS = null;
        textP = null;
        textR = null;
        textC = null;
    }

    public ReadyScript(ReadyScript rs)
    {
        textN = rs.textN;
        textC = rs.textC;
        textS = rs.textS;
        textP = rs.textP;
        textR = rs.textR;
        textY = rs.textY;
    }

    public ReadyScript(string n, string y, string s, string p, string r, string c)
    {
        n = textN;
        y = textY;
        s = textS;
        p = textP;
        r = textR;
        c = textC;
    }

    void Awake()
    {
        if ((!File.Exists(Application.dataPath + "/info.txt"))&& (!File.Exists(Application.dataPath + "/names.txt")))
        {
            FileStream fileI = new FileStream(Application.dataPath + "/info.txt", FileMode.Create);
            fileI.Close();

            FileStream fileN = new FileStream(Application.dataPath + "/names.txt", FileMode.Create);
            fileN.Close();
        }
        else if (!File.Exists(Application.dataPath + "/info.txt"))
        {
            FileStream fileI = new FileStream(Application.dataPath + "/info.txt", FileMode.Create);
            fileI.Close();
        }
        else if (!File.Exists(Application.dataPath + "/names.txt"))
        {
            FileStream fileN = new FileStream(Application.dataPath + "/names.txt", FileMode.Create);
            fileN.Close();
        }
    }

    void Start()
    {
        Error.SetActive(false);
    }

    public void Ready()
    {
        textN = Name.text.ToString();
        textY = Year.text.ToString();
        textP = Place.text.ToString();
        textS = Structure.text.ToString();
        textR = Repertoire.text.ToString();
        textC = Cities.text.ToString();

        if ((textN != "") && (textY != "") && (textP != "") && (textS != "") && (textR != "") && (textC != ""))
        {
            string file_info = Application.dataPath + "/info.txt";
            string file_names = Application.dataPath + "/names.txt";

            StreamReader sri = new StreamReader(file_info);

            string line;

            while ((line = sri.ReadLine()) != null)
            {
                if (line.StartsWith(textN + ";"))
                {
                    Error.SetActive(true);
                    text.text = "Группа с таким именем уже существует";

                    return;
                }

                if (line.EndsWith(";" + textP))
                {
                    Error.SetActive(true);
                    text.text = "Это место в хит-параде уже занято";

                    return;
                }
            }
            sri.Close();

            string Data = textN + ";" + textY + ";" + textS + ";" + textR + ";" + textC + ";" + textP;


            using (StreamWriter sw = File.AppendText(file_info))
            {
                sw.WriteLine(Data);
                sw.Close();
            }

            using (StreamWriter st = File.AppendText(file_names))
            {
                st.WriteLine(textN);
                st.Close();
            }

            Sort(file_names);
            SceneManager.LoadScene("main");
        }
        else
        {
            Error.SetActive(true);
            text.text = "Одно из полей не заполнено";
        }
    }


    void Sort(string file_names)
    {
        string[] readNames = System.IO.File.ReadAllLines(file_names);

        Array.Sort(readNames);

        using (System.IO.StreamWriter fileN = new System.IO.StreamWriter(file_names, false))
        {
            for (int j = 0; j < readNames.Length; j++)
            {
                fileN.WriteLine(readNames[j]);
            }

            fileN.Close();
        }
    }
}
