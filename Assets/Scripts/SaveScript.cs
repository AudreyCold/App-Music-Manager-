using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveScript : PressChange
{
    string textN, textY, textS, textP, textR, textC;

    public GameObject Error;
    public Text text_error;

    public SaveScript()
    {
        textN = null;
        textY = null;
        textS = null;
        textP = null;
        textR = null;
        textC = null;
    }

    public SaveScript(SaveScript rs)
    {
        textN = rs.textN;
        textC = rs.textC;
        textS = rs.textS;
        textP = rs.textP;
        textR = rs.textR;
        textY = rs.textY;
    }

    public SaveScript(string n, string y, string s, string p, string r, string c)
    {
        n = textN;
        y = textY;
        s = textS;
        p = textP;
        r = textR;
        c = textC;
    }

    void Start()
    {
        Error.SetActive(false);
    }

    public void Ready()
    {
        string file_info = Application.dataPath + "/info.txt";
        string file_names = Application.dataPath + "/names.txt";

        StreamReader sri = new StreamReader(file_info);
        StreamReader srn = new StreamReader(file_names);

        StreamReader srline = new StreamReader(file_info);

        string newData;
        string line;
        string name;

        string ln;

        textN = Name_if.text.ToString();
        textY = Year_if.text.ToString();
        textP = Place_if.text.ToString();
        textS = Names_if.text.ToString();
        textR = Repertoire_if.text.ToString();
        textC = Cities_if.text.ToString();

        if ((textN != "") && (textY != "") && (textP != "") && (textS != "") && (textR != "") && (textC != ""))
        {
            while ((ln = srline.ReadLine()) != null)
            {
                if ((ln.StartsWith(textN + ";"))&& (textN != first_name))
                {
                        Error.SetActive(true);
                        text_error.text = "Группа с таким именем уже существует";

                        return;
                }

                if ((ln.EndsWith(";" + textP))&& (textP != first_place))
                {
                        Error.SetActive(true);
                        text_error.text = "Это место в хит-параде уже занято";

                        return;
                }
            }
            srline.Close();

            newData = textN + ";" + textY + ";" + textS + ";" + textR + ";" + textC + ";" + textP;

            //////new Dates///////
            while ((line = sri.ReadLine()) != null)
            {
                if (line.StartsWith(first_name + ";") == true)
                {
                    sri.Close();
                    break;
                }
            }

            while ((name = srn.ReadLine()) != null)
            {
                if (name.StartsWith(first_name) == true)
                {
                    srn.Close();
                    break;
                }
            }
            ///////new Dates///////


            string new_Info = string.Empty;
            
            using (System.IO.StreamReader readerI = System.IO.File.OpenText(file_info))
            {
                new_Info = readerI.ReadToEnd();
                readerI.Close();
            }
            new_Info = new_Info.Replace(line, newData);

            using (System.IO.StreamWriter fileI = new System.IO.StreamWriter(file_info))
            {
                fileI.Write(new_Info);
                fileI.Close();
            }


            string new_Name = string.Empty;

            using (System.IO.StreamReader readerN = System.IO.File.OpenText(file_names))
            {
                new_Name = readerN.ReadToEnd();
                readerN.Close();
            }

            new_Name = new_Name.Replace(name, textN);

            using (System.IO.StreamWriter fileN = new System.IO.StreamWriter(file_names))
            {
                fileN.Write(new_Name);
                fileN.Close();
            }

            Sort();

            SceneManager.LoadScene("main");
        }
        else
        {
            Error.SetActive(true);
            text_error.text = "Одно из полей не заполнено";
        }
    }

    public void Sort()
    {
        string file_names = Application.dataPath + "/names.txt";

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


