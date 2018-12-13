using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SL : MonoBehaviour
{

	public List<string> Name = new List<string>();
	public List<Vector3> Pos = new List<Vector3>();
	public List<int> Remaining = new List<int>();
	public List<String> UI = new List<String>();
	public List<GameObject> UILoading = new List<GameObject>();
	public int number;
	public int UInumber;
	public bool saved;

	public static SL SaveLoad;
	
	void Awake()
	{
		if (SaveLoad == null)
		{
			SaveLoad = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	/*void Awake()
	{
		DontDestroyOnLoad(this);
	}*/
	
	public void Save()
	{
		print("Saved");
		Name.Clear();
		Pos.Clear();
		Remaining.Clear();
		UI.Clear();
		UInumber = 0;
		number = 0;
		saved = true;
		
		foreach (GameObject savedset in FindObjectsOfType<GameObject>())
		{
			if (savedset.name.Contains("(Clone)") && savedset.name.Contains("Set"))
			{
				print(savedset.name);
				print(savedset.name.Length);
				Name.Add(savedset.name.Substring(0, savedset.name.Length-7));
				print(Name[number]);
				Pos.Add(savedset.transform.position);
				number++;
			}
			else if (savedset.name.Contains("Set") && savedset.CompareTag("UI"))
			{
				UI.Add(savedset.name);
				Remaining.Add(savedset.GetComponent<CreateSets>().Amount);
				UInumber++;
			}
		}
	}

	public void Load()
	{
		if (saved)
		{
			UILoading.Clear();
			print("Loaded");
			print(number);
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
			foreach (GameObject Settodelete in FindObjectsOfType<GameObject>())
			{
				if (Settodelete.name.Contains("(Clone)") && Settodelete.name.Contains("Set"))
				{
					Destroy(Settodelete);
				}

			}

			for (int i = 0; i < number; i++)
			{
				print(Name[i]);
				GameObject set = Instantiate(Resources.Load<GameObject>("Prefabs/" + Name[i]));
				set.GetComponent<MouseMoverSnap>().isSelected = false;
				set.transform.position = Pos[i];
				set.GetComponent<MouseMoverSnap>().Placed = true;
			}

			for (int i = 0; i < UInumber; i++)
			{
				foreach (GameObject loadedset in FindObjectsOfType<GameObject>())
				{
					if (loadedset.name == UI[i] && loadedset.CompareTag("UI"))
					{
						UILoading.Add(loadedset);
					}
				}
			}
		}


		for (int i = 0; i < UInumber; i++)
		{
			UILoading[i].GetComponent<CreateSets>().Amount = Remaining[i];
		}
	}
}