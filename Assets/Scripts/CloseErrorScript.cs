using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseErrorScript : MonoBehaviour
{
    public GameObject GameObj;

    virtual public void CloseGameObj()
    {
        GameObj.SetActive(false);
    }

}
