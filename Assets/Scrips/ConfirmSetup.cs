using System.Collections;
using System.Collections.Generic;
using ProBuilder2.Common;
using UnityEngine;

public class ConfirmSetup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnClick()
	{
		print("Confirm Setup");
		GameObject.Find("Starting Block").GetComponent<Push>().Setup = true;//Make the starting block able to be push
		
		GameObject[] Sets = GameObject.FindGameObjectsWithTag("Set");
		Debug.Log(Sets.Length);
		for (int i = 0; i < Sets.Length; i++)
		{
			Sets[i].GetComponent<MeshCollider>().enabled = false;
		}//Disable the collider of domino sets
		
		GameObject[] Dominos = GameObject.FindGameObjectsWithTag("Domino");
		Debug.Log(Dominos.Length);
		for (int i = 0; i < Dominos.Length; i++)
		{
			Dominos[i].GetComponent<Rigidbody>().isKinematic = false;
		}//Enable physics of domino
		
		GameObject[] UIs = GameObject.FindGameObjectsWithTag("UI");
		Debug.Log(UIs.Length);
		for (int i = 0; i < UIs.Length; i++)
		{
			Destroy(UIs[i]);
		}//Remove UI
	}
	
}
