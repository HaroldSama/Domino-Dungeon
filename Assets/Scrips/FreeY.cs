using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeY : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GetComponent<Rigidbody>().velocity.magnitude > 0.1)
		{
			StartCoroutine(waiterLose());
		}

	}
	
	IEnumerator waiterLose()
	{
		yield return new WaitForSeconds(3);
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
	}
}
