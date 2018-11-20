using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMover : MonoBehaviour
{

	public bool isSelected = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isSelected) // if the ball is selected
		{
			print("Selected");
			//get the position of the mouse and convert it to unity units
			Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

//			print(mouseWorldPos);
			mouseWorldPos.x = mouseWorldPos.x - mouseWorldPos.y * 0.5f;
			mouseWorldPos.z = mouseWorldPos.z - mouseWorldPos.y * 0.5f;
			mouseWorldPos.y = 1; //change the z position to be the right plane
			
			transform.position = mouseWorldPos; //move the transform position to be the mouse world position

			if (Input.GetMouseButtonDown(0)) // if someone clicks while the ball is selected
			{
				isSelected = false; //make it unselected
			}
		}
	}

	void OnMouseUp() //called when you click on this gameObject w/ physics
	{
		print("Placed");
		//GameObject.Find("Starting Block").GetComponent<Push>().enabled = true;
		isSelected = true;  //turn isSelected on
	}
}
