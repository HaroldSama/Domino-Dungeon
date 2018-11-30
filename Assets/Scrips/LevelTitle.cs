using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTitle : MonoBehaviour
{

	public Text Title;

	// Use this for initialization
	void Start ()
	{

		Title.text = SceneManager.GetActiveScene().name;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
