using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

	public int currentLevelNumber;

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
		SceneManager.LoadScene(currentLevelNumber + 1, LoadSceneMode.Single);
	}

}
