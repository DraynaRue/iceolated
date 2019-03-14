using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObjective : MonoBehaviour 
{
	public int questNumber;
	public QuestManager theQM;
	public Text questText;
	public Text subQuestText;
	public string questString;
	public string subQuestString;
	public Text itemQuestProgress;
	public bool isItemQuest;
	public string targetItem;
	public int numberOfItems;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
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
		questText.text = questString;
		subQuestText.text = subQuestString;
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
		questText.text = null;
		theQM.questCompleted[questNumber] = true;
		gameObject.SetActive(false);
	}
}
