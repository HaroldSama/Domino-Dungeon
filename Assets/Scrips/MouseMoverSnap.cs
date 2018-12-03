using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoverSnap : MonoBehaviour
{

	public bool isSelected = true;
	public bool Blocked = true;
	public bool Placed;
	public bool WithinRange;
	public float xadjust;
	public float zadjust;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isSelected) // if the set is selected
		{
			
			Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//get the position of the mouse and convert it to unity units
	
		   //Debug.Log(Input.mousePosition + "   " + mouseWorldPos);
           //print(mouseWorldPos);
			mouseWorldPos.x = mouseWorldPos.x - mouseWorldPos.y * 0.5f;
			mouseWorldPos.z = mouseWorldPos.z - mouseWorldPos.y * 0.5f;
			mouseWorldPos.y = 0;
			mouseWorldPos.x = Mathf.RoundToInt(mouseWorldPos.x / 2);
            mouseWorldPos.x = mouseWorldPos.x * 2 - 1 + xadjust;
            mouseWorldPos.z = Mathf.RoundToInt(mouseWorldPos.z / 2);
            mouseWorldPos.z = mouseWorldPos.z * 2 + zadjust;
			
			transform.position = mouseWorldPos; //move the transform position to be the mouse world position

        
            //put the set down if mouse clicked
			if (Input.GetMouseButtonDown(0)) 
			{
				if (Placed == false && Blocked == false && WithinRange)
				{
					isSelected = false;
					GameObject.Find("Floating Control").GetComponent<FloatingControl>().Floating = false;
					//gameObject.isStatic = true;
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
		
		//print("Put here!");
		//Blocked = false;

		//if the domino set is within the tray
		if (transform.position.x < 8 && 
		    transform.position.x > -2 && 
		    transform.position.z < 1 && 
		    transform.position.z > -9)
		{
			//print("In the Range!");
			WithinRange = true;
		}
		else
		{
			//print("Out of Range!");
			WithinRange = false;
		}
	}
		
	void OnTriggerExit(Collider other) 
	{
		if (other.CompareTag("Set"))
		{
			//print(other.name);
			//print("Put here!");
			Blocked = false;
		}
	}
	
	//Blocked when a domino set overlap with another one
	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Set") /*&& Vector3.Distance(other.transform.position, transform.position) < 1*/)
		{
			//print(other.name);
            //print("Can't put here!");
            Blocked = true;
		}
	}
	
	//remove the placed set
	void OnMouseDown() 
	{
		if (Placed && 
		    GameObject.Find("Floating Control").GetComponent<FloatingControl>().Floating == false && 
		    GameObject.Find("Starting Block").GetComponent<Push>().Fixed == false)
		{
			isSelected = true;
			GameObject.Find("Floating Control").GetComponent<FloatingControl>().Floating = true;
			//gameObject.isStatic = false;
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
