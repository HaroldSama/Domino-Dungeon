using System;
using System.Collections;
using System.Collections.Generic;
using ProBuilder2.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmSetup : MonoBehaviour
{

	//public bool Resetting;
	public GameObject WinningDetector;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//if the confirm button is clicked
	public void Confirm()
	{
		print("Confirm Setup");
		foreach(GameObject StartingBlock in FindObjectsOfType<GameObject>())
		{
			if(StartingBlock.name == "Starting Block")
			{
				StartingBlock.GetComponent<Push>().Setup = true;
				StartingBlock.GetComponent<Push>().Fixed = true;
			}
		}
		//GameObject.Find("Starting Block").GetComponent<Push>().Setup = true;//Make the starting block able to be push
		//GameObject.Find("Starting Block").GetComponent<Push>().Fixed = true;//Make the sets unable to removed
		WinningDetector.SetActive(true);//Active Winning Detect
		
		/*GameObject[] Sets = GameObject.FindGameObjectsWithTag("Set");
		Debug.Log(Sets.Length);
		for (int i = 0; i < Sets.Length; i++)
		{
			Sets[i].GetComponent<MeshCollider>().enabled = false;
		}*///Disable the collider of domino sets
		
		GameObject[] Dominos = GameObject.FindGameObjectsWithTag("Domino");
		//Debug.Log(Dominos.Length);
		for (int i = 0; i < Dominos.Length; i++)
		{
			Dominos[i].GetComponent<MeshCollider>().enabled = true;
			Dominos[i].GetComponent<Rigidbody>().isKinematic = false;
			//Dominos[i].GetComponent<MouseMoverSnap>().Fixed = true;
		}//Enable physics of dominos
		
		GameObject[] Bricks = GameObject.FindGameObjectsWithTag("Brick");
		//Debug.Log(Bricks.Length);
		for (int i = 0; i < Bricks.Length; i++)
		{
			Bricks[i].GetComponent<MeshCollider>().enabled = true;
			Bricks[i].GetComponent<Rigidbody>().isKinematic = false;
		}
		
		GameObject[] UIs = GameObject.FindGameObjectsWithTag("UI");
		//Debug.Log(UIs.Length);
		for (int i = 0; i < UIs.Length; i++)
		{
			Destroy(UIs[i]);
		}//Remove UI
	}

	//if the reset button is clicked
	public void Reset()
	{
		print("Reset");
		/*Resetting = true;
		GameObject[] Sets = GameObject.FindGameObjectsWithTag("Set");
		if (Sets.Length == 1)
		{
			Resetting = false;
		}*/
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
	}
	
}
