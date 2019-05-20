using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("LastestScene"))
        {
            Button btn = GameObject.Find("ContinueButton").gameObject.GetComponent<Button>();
            btn.interactable = true;
        }
    }

    //获取选关按钮对应的数字
    public int getBtnNum()
    {
        GameObject currentButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;  //获取最近选择的button物体
        Button btn = currentButton.gameObject.GetComponent<Button>();  //获取button物体的button组件（这句可有可无）
        Text txt = currentButton.GetComponentInChildren<Text>();  //获取button物体的Text子物体
        string BtnTextNum = txt.text;

        return int.Parse(BtnTextNum);    //string型转为int型
    }
    /*----------------------------------------------------------主界面----------------------------------------------------------*/
    //继续游戏
    public void btn_continue()
    {
        int LastestScene = PlayerPrefs.GetInt("LastestScene");
        SceneManager.LoadScene(LastestScene, LoadSceneMode.Single);
    }

    //开始游戏
    public void btn_play()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    //进入选关界面
    public void btn_choosingScene()
    {
        SceneManager.LoadScene(17, LoadSceneMode.Single);
    }

    /*---------------------------------------------------------选关界面---------------------------------------------------------*/
    //选关按钮
    public void btn_sceneNum()
    {
        int sceneNum = getBtnNum();
        SceneManager.LoadScene(sceneNum, LoadSceneMode.Single);  //载入指定场景
    }

    /*---------------------------------------------------------关卡界面---------------------------------------------------------*/

    /*-------------------------------------------------------所有界面共用-------------------------------------------------------*/
    //返回主界面
    public void btn_returnMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }


}
