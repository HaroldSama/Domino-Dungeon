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
	
		public void OnMouseUp()
	{
		print("Generate " + name);
		GameObject set = Instantiate(Resources.Load<GameObject>("Prefabs/" + name)); //create a new Set
		
		Sets.Add(set);
	}
}
