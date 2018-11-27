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
		if (isSelected) // if the set is selected
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
			
			transform.position = mouseWorldPos; //move the transform position to be the mouse world position

        

			if (Input.GetMouseButtonDown(0)) 
			{
				if (Placed == false && Blocked == false)
				{
					isSelected = false;
					//GetComponentInChildren<MeshCollider>().enabled = true;
				}
			}
		}
		
			
		if (Input.GetMouseButtonUp(0)) 
		{
    		if (isSelected == false)
    		{
    			Placed = true; 
    		}
    
    	}
	}
	
	void OnTriggerEnter(Collider other)
	{
		print(other.name);
		print("Can't put here!");
		Blocked = true;
	}
	
	void OnTriggerExit(Collider other) 
	{
		print("Can put here!");
		Blocked = false;
	}

	void OnMouseDown() 
	{
		if (Placed)
		{
			isSelected = true; 
			//GetComponentInChildren<MeshCollider>().enabled = false;
		}
	}

	void OnMouseUp() 
	{
		if (isSelected)
		{
			Placed = false; 
		}
		//GameObject.Find("Starting Block").GetComponent<Push>().enabled = true;
		
	}
}
