using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{


	public Vector3 FPosAdjust = new Vector3(1, 3, 0);
	public int Force = 1000;
	public bool Setup;
	public bool Fixed;
	private bool Pushed;
	private bool MovementTesting;
	private int MovementCounts;
	public float SpeedTreshold;
	public GameObject WinningDetector;

	private List<Rigidbody> Dominos = new List<Rigidbody>();
	private Rigidbody rb;
	private Winning _winning;

	private void Awake()
	{
		_winning = WinningDetector.GetComponent<Winning>();
		rb = GetComponent<Rigidbody>();
	}

	// Use this for initialization
	void Start()
	{

	}

	//if the starting block is pushed
	public void OnMouseDown()
	{
		if (Setup)
		{
			print("Got a click");
			GetComponent<Rigidbody>().isKinematic = false;
			GetComponent<Rigidbody>().AddForceAtPosition(-transform.forward * Force, transform.position + FPosAdjust,
				ForceMode.Impulse);
			Setup = false;
			Pushed = true;
			GameObject[] DominoObjs = GameObject.FindGameObjectsWithTag("Domino");
			print(DominoObjs.Length);
			for (int i = 0; i < DominoObjs.Length; i++)
			{
				Dominos.Add(DominoObjs[i].GetComponent<Rigidbody>());
			}
		}
	}


	// Update is called once per frame
	void Update()
	{
		//start movement test
		if (Pushed && rb.velocity.magnitude > SpeedTreshold)
		{
			MovementTesting = true;
			//print("Movement Testing");
			Pushed = false;
		}

		//movement test
		if (MovementTesting)
		{
			//MovementTesting = false;
    		//GameObject[] Dominos = GameObject.FindGameObjectsWithTag("Domino");
        	//Debug.Log(Dominos.Length);
			MovementCounts = Dominos.Count;
		    for (int i = 0; i < Dominos.Count; i++)
		    {
			    if (Dominos[i].velocity.magnitude > SpeedTreshold)
			    {
				    print(Dominos[i].name);
			    }
			    else
			    {
				    MovementCounts--;
			    }
		    }

			if (MovementCounts == 0)
			{
				MovementTesting = false;
				_winning.StaticCount++;
			}
		}

		
	}
}
