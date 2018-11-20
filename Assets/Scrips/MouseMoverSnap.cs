using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MouseMoverSnap : MonoBehaviour
{

	public bool isSelected = true;
	public bool Blocked = false;
	public bool Placed = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isSelected) // if the ball is selected
		{
			//get the position of the mouse and convert it to unity units
			Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

//			print(mouseWorldPos);
			mouseWorldPos.x = mouseWorldPos.x - mouseWorldPos.y * 0.5f;
			mouseWorldPos.z = mouseWorldPos.z - mouseWorldPos.y * 0.5f;
			mouseWorldPos.y = 0;
			mouseWorldPos.x = Mathf.RoundToInt(mouseWorldPos.x / 2);
            mouseWorldPos.x = mouseWorldPos.x * 2 - 1;
            mouseWorldPos.z = Mathf.RoundToInt(mouseWorldPos.z / 2);
            mouseWorldPos.z = mouseWorldPos.z * 2;
			
			 //change the z position to be the right plane
			
			transform.position = mouseWorldPos; //move the transform position to be the mouse world position

        

			if (Input.GetMouseButtonDown(0)) // if someone clicks while the ball is selected
			{
				if (Placed == false)
				{
					isSelected = false; //make it unselected
				}
			}
		}
		
			
		if (Input.GetMouseButtonUp(0)) // if someone clicks while the ball is selected		
		{
    		if (isSelected == false)
    		{
    			Placed = true; //make it unselected
    		}
    
    	}
	}
	
	void OnCollisionEnter(Collision col) 
	{
		print("Can't put here!");
		Blocked = true;
	}
	
	void OnCollisionExit(Collision col) 
	{
		print("Can put here!");
		Blocked = false;
	}

	void OnMouseDown() //called when you click on this gameObject w/ physics
	{
		if (Placed)
		{
			isSelected = true; //turn isSelected on
		}
	}

	void OnMouseUp() //called when you click on this gameObject w/ physics
	{
		if (isSelected)
		{
			Placed = false; //turn isSelected on
		}
		//GameObject.Find("Starting Block").GetComponent<Push>().enabled = true;
		
	}
}
