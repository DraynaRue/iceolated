﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItemM : MonoBehaviour 
{
	public int questNumber;
	public QuestManager theQM;
	public string itemName;
	private bool got = false;
	public bool greg = false;
	// Use this for initialization
	void Start () 
	{
		theQM = FindObjectOfType<QuestManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (theQM != null)
		{
			if (!theQM.questCompleted[questNumber] && theQM.quests[questNumber].gameObject.activeSelf && got == false && Input.GetAxis("Interact") > 0 && greg == true)
			{
				theQM.itemCollected = itemName;
				got = true;
			}
		}
	}
	private void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.name == "_Player")
		{
			greg = true;
		}	
	}

		private void OnTriggerExit(Collider other) 
	{
		if (other.gameObject.name == "_Player")
		{
			greg = false;
		}	
	}
}
