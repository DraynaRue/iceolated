﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour 
{
	public QuestObjective[] quests;
	public bool[] questCompleted;

	public string itemCollected;
	public int numberOfItemsCollected;
	// Use this for initialization
	void Start () 
	{
		questCompleted = new bool[quests.Length];
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
