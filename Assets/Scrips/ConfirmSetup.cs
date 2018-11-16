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
	
	public void OnMouseDown()
	{
		print("Confirm Setup");
		GameObject.Find("Starting Block").GetComponent<Push>().Setup = true;
		GameObject[] Dominos = GameObject.FindGameObjectsWithTag("Domino");
		Debug.Log(Dominos.Length);
		for (int i = 0; i < Dominos.Length; i++)
		{
			Dominos[i].GetComponent<Rigidbody>().isKinematic = false;
		}
	}
	
}
