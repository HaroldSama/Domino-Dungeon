using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoverSnap : MonoBehaviour
{

	public bool isSelected = true;
	public bool Blocked;
	public bool Placed;
	public bool WithinRange;
	public float xadjust;
	public float yadjust;
	public float zadjust;

	private TraySize _traySize;
	private FloatingControl _floatingControl;
	private AudioSource _audioSource;

	private void Awake()
	{
		_traySize = GameObject.Find("TraySize").GetComponent<TraySize>();
		_floatingControl = GameObject.Find("Floating Control").GetComponent<FloatingControl>();
		_audioSource = GetComponent<AudioSource>();
	}

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
			mouseWorldPos.y = yadjust;
			mouseWorldPos.x = Mathf.RoundToInt(mouseWorldPos.x / 2);
            mouseWorldPos.x = mouseWorldPos.x * 2 - 1 + xadjust;
            mouseWorldPos.z = Mathf.RoundToInt(mouseWorldPos.z / 2);
            mouseWorldPos.z = mouseWorldPos.z * 2 - 1 + zadjust;
			
			transform.position = mouseWorldPos; //move the transform position to be the mouse world position

        
            //put the set down if mouse clicked
			if (Input.GetMouseButtonDown(0)) 
			{
				if (Placed == false && Blocked == false && WithinRange)
				{
					isSelected = false;
					_floatingControl.Floating = false;
					GameObject smog = Instantiate(Resources.Load<GameObject>("Particle/SmogEmit"), mouseWorldPos + new Vector3(0, 0.5f, 0), new Quaternion(0,0,0,0));
					//smog.transform.position = mouseWorldPos + new Vector3(0, 0.5f, 0);
					_audioSource.Play();
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
		if (transform.position.x < _traySize.xmax && 
		    transform.position.x > _traySize.xmin && 
		    transform.position.z < _traySize.zmax && 
		    transform.position.z > _traySize.zmin)
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
		if (other.CompareTag("Set") || other.CompareTag("Wall"))
		{
			//print(other.name);
			//print("Put here!");
			Blocked = false;
		}
	}
	
	//Blocked when a domino set overlap with another one
	void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Set") || other.CompareTag("Wall")/*&& Vector3.Distance(other.transform.position, transform.position) < 1*/)
		{
			print(other.name);
            //print("Can't put here!");
            Blocked = true;
		}
	}
	
	//remove the placed set
	void OnMouseDown() 
	{
		if (Placed && 
		    _floatingControl.Floating == false && 
		    GameObject.Find("Starting Block").GetComponent<Push>().Fixed == false)
		{
			isSelected = true;
			_floatingControl.Floating = true;
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
