using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmogDisappear : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		StartCoroutine(waiterWin());
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
	
	IEnumerator waiterWin()
	{
		yield return new WaitForSeconds(1);
		Destroy(gameObject);	
	}
}
