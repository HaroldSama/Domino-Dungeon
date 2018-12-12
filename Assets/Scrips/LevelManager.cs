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
	}
	
	public void Reset()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
	}
	
	public void Next()
	{
		SL = GameObject.Find("SL");
		Destroy(SL);
		SceneManager.LoadScene(currentLevelNumber + 1, LoadSceneMode.Single);
	}

}
