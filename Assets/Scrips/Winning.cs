using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winning : MonoBehaviour
{

	public int StartPoint = 1;
	public int StaticCount;
	public bool ExitOpen;
	public GameObject Restart;
	public GameObject Next;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//losing condition
		if (StaticCount == StartPoint && ExitOpen == false)
		{
			StartCoroutine(waiterLose());
		}

		if (ExitOpen)
		{
			StartCoroutine(waiterWin());
		}
	}
    
    void OnTriggerStay(Collider other)
    {
	    ExitOpen = false;
    }
	
	void OnTriggerExit(Collider other)
	{
		ExitOpen = true;
	}

	IEnumerator waiterLose()
	{
		yield return new WaitForSeconds(0);
		Restart.SetActive(true);		
	}
	
	IEnumerator waiterWin()
	{
		yield return new WaitForSeconds(0);
		Next.SetActive(true);		
	}
}
