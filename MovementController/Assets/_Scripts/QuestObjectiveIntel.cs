using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObjectiveIntel : MonoBehaviour 
{
	public int questNumber; //current quest
	public QuestManagerIntel theQM; //reference script
	public Text itemQuestProgress; //text for UI
	public bool isItemQuest; //Is this an item quest
	public string targetItem; //Name of items
	public int numberOfItems; //number of items to collect
	public Mission4 mission4; //reference to script


	void Update () 
	{
		if (isItemQuest) //if there are items to be collected{
		{
			if (itemQuestProgress.gameObject.activeSelf == false) //if the ui for quest progress is inactive, set it to active;
			{
				itemQuestProgress.gameObject.SetActive(true);
			}

			itemQuestProgress.text = theQM.numberOfItemsCollected + "/" + numberOfItems; //UI displays the quest managers 

			if (theQM.itemCollected == targetItem)
			{
				theQM.itemCollected = null;
				theQM.numberOfItemsCollected++;
				if (theQM.numberOfItemsCollected >= numberOfItems)
				{
					EndQuest();
				}
			}
		}
		else if (isItemQuest == true)
		{
			itemQuestProgress.gameObject.SetActive(false);
		}
	}

	public void StartQuest ()
	{
		if (isItemQuest)
		{
			theQM.numberOfItemsCollected = 0;
		}
	}
	public void EndQuest ()
	{
		if (isItemQuest)
		{
			numberOfItems = 0;
			theQM.numberOfItemsCollected = 0;
			itemQuestProgress.text = "";
			itemQuestProgress.gameObject.SetActive(false);
		}
		mission4.Mission4Start();
		Debug.Log("MISSION 4");
		theQM.questCompleted[questNumber] = true;
		

		//Start Mission 4
		

		gameObject.SetActive(false);

		
	}
}
