using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingControl : MonoBehaviour
{

	public bool Floating;
	public GameObject EventSystem;

	// Use this for initialization
	void Start (){

	}
	
	// Update is called once per frame
	void Update () {
		
		if (Floating)
		{
			EventSystem.SetActive(false);
		}
		else
		{
			EventSystem.SetActive(true);
		}
	}
}
