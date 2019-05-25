using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

	public int currentLevelNumber;
	public GameObject SL;

	void Start ()
	{
		currentLevelNumber = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LastestScene", currentLevelNumber);
    }
	
	public void Reset()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
	}
	
	public void Next()
	{
		SL = GameObject.Find("SL");
		Destroy(SL);
        PlayerPrefs.SetInt("PassedNum", ++currentLevelNumber);
        SceneManager.LoadScene(currentLevelNumber, LoadSceneMode.Single);
	}

}
