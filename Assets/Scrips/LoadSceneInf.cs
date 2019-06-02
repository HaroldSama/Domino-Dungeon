using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneInf : MonoBehaviour
{
    void Start()
    {
        int PassedNum = PlayerPrefs.GetInt("PassedNum");

        for(int i = 1; i <= PassedNum; i++)
        {
            string ButtonNum = i.ToString();  //转换为string类型
            Button btn = GameObject.Find(ButtonNum).GetComponent<Button>();
            btn.interactable = true;

        }
    }
}
