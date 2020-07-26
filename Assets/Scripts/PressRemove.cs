using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class PressRemove : ButtonScript
{
    public Text text;

    void Awake()
    {
        generated();
    }

    public override void press(string name)
    {
        AllGroups.SetActive(false);

        text.text = name;
    }
}