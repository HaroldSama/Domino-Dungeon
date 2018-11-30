using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSets : MonoBehaviour {
	
	List<GameObject> Sets = new List<GameObject>();
	public int Amount = 4;
	public GameObject FloatingControl;
	public GameObject ResetButton;

	// Use this for initialization
	void Start () {
		
	GetComponentInChildren<Text>().text = "" + Amount;	
		
	}
	
	// Update is called once per frame
	void Update () {

		//if reset button is pressed
		if (ResetButton.GetComponent<ConfirmSetup>().Resetting)
		{
			foreach(GameObject setstoRemove in FindObjectsOfType<GameObject>())
			{
				if(setstoRemove.name == name + "(Clone)")
				{
					Destroy(setstoRemove);
					Amount++;
				}
			}
			
			GetComponentInChildren<Text>().text = "" + Amount;
			ResetButton.GetComponent<ConfirmSetup>().Resetting = false;
		}
		
	}
	

	//if the prefab is clicked
	public void OnMouseUp()
	{
		if (Amount > 0)
		{
			print("Generate " + name);
    		GameObject set = Instantiate(Resources.Load<GameObject>("Prefabs/" + name)); //create a new Set
    		Amount--;
    		GetComponentInChildren<Text>().text = "" + Amount;		
			Sets.Add(set);
			FloatingControl.GetComponent<FloatingControl>().Floating = true;
		}
	}
}
