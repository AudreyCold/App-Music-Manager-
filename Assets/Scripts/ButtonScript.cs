using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

abstract public class ButtonScript : MonoBehaviour
{
    public Transform panel;
    public Font font;

    public GameObject AllGroups;

    abstract public void press(string name);

    protected void generated()
    {
        string file_info = Application.dataPath + "/info.txt";
        string file_names = Application.dataPath + "/names.txt";

        using (StreamReader sr = new StreamReader(file_names))
        {
            string line;
            int y = 0;
            int i = System.IO.File.ReadAllLines(file_names).Length;

            for (int k = 0; k < i; k++)
            {
                line = sr.ReadLine();

                GameObject newButton = new GameObject("Button" + k, typeof(Image), typeof(Button), typeof(LayoutElement));

                ButtonSettings(newButton);
                RectTransformButton(newButton, y);

                GameObject newText = new GameObject("Text" + k, typeof(Text));

                TextSettings(newButton, newText, line);
                RectTransformText(newText);

                newButton.GetComponent<Button>().onClick.AddListener(delegate { press(newText.GetComponent<Text>().text); });

                y += 50;
            }
        }
    }

    void ButtonSettings(GameObject newButton)
    {
        newButton.transform.SetParent(panel);
        newButton.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        newButton.GetComponent<LayoutElement>().minHeight = 40;
    }

    void TextSettings(GameObject newButton, GameObject newText, string line)
    {
        newText.transform.SetParent(newButton.transform);
        newText.GetComponent<Text>().text = line;
        newText.GetComponent<Text>().font = font;
        newText.GetComponent<Text>().fontSize = 30;
        newText.GetComponent<Text>().color = new Color(0, 0, 0);
        newText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
    }

    void RectTransformButton(GameObject newButton, int y)
    {
        RectTransform rect = newButton.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0, 1);
        rect.anchorMax = new Vector2(0, 1);
        rect.anchoredPosition = new Vector3(284, -40 - y, 0);
        rect.sizeDelta = new Vector2(561, 40);
        rect.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    void RectTransformText(GameObject newText)
    {
        RectTransform rt = newText.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0, 0);
        rt.anchorMax = new Vector2(1, 1);
        rt.anchoredPosition = new Vector2(0, 0);
        rt.sizeDelta = new Vector2(0, 0);
        rt.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
}




