using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObjectiveIntel : MonoBehaviour 
{
	public int questNumber;
	public QuestManagerIntel theQM;
	public Text itemQuestProgress;
	public bool isItemQuest;
	public string targetItem;
	public int numberOfItems;

	public Mission4 mission4;

	void Update () 
	{
		if (isItemQuest)
		{
			if (itemQuestProgress.gameObject.activeSelf == false)
			{
				itemQuestProgress.gameObject.SetActive(true);
			}

			itemQuestProgress.text = theQM.numberOfItemsCollected + "/" + numberOfItems;

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
