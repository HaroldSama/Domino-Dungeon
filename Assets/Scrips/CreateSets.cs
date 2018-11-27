using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSets : MonoBehaviour {
	
	List<GameObject> Sets = new List<GameObject>();
	public int Amount = 4;

	// Use this for initialization
	void Start () {
		
	GetComponentInChildren<Text>().text = "" + Amount;	
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	

	
		public void OnMouseUp()
	{
		if (Amount > 0)
		{
			print("Generate " + name);
    		GameObject set = Instantiate(Resources.Load<GameObject>("Prefabs/" + name)); //create a new Set
    		Amount = Amount - 1;
    		GetComponentInChildren<Text>().text = "" + Amount;		
			Sets.Add(set);
		}
	}
}
