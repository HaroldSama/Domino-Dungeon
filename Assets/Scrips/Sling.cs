using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling : MonoBehaviour {
	
	public SL _sl;
	private GameObject Sler;
	
	// Use this for initialization
	void Start ()
	{
		Sler = GameObject.Find("SL");
		//print(1);
		_sl = Sler.GetComponent<SL>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void saving()
	{
		_sl.Save();
	}

	public void loading()
	{
		_sl.Load();
	}
}
