using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

	public int Level;
	private string String;

	// Use this for initialization
	void Start ()
	{
        String = SceneManager.GetActiveScene().name;
		String = String.Substring(String.Length - 1);
		Level = Convert.ToInt32(String); 	
	} 	
	
	// Update is called once per frame
                        	void Update () { 	
		
	}

	public void OnClick()
	{
    	SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
	}

	public void Next()
	{
		Level++;
		SceneManager.LoadScene("Level " + Level, LoadSceneMode.Single);
	}
    		
}
