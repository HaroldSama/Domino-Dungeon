using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmogDisappear : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		StartCoroutine(waiter());
	}

	IEnumerator waiter()
	{
		yield return new WaitForSeconds(1);
		Destroy(gameObject);	
	}
}
