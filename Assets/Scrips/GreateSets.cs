using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreateSets : MonoBehaviour {
	
	List<GameObject> Sets = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
		public void OnMouseDown()
	{
		print("Generate " + name);
		GameObject set = Instantiate(Resources.Load<GameObject>("Prefabs/SetNormalX")); //create a new ball
		
		Sets.Add(set);
	}
}
