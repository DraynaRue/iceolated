using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObjective : MonoBehaviour 
{
	public int questNumber;
	public QuestManager theQM;
	public Text questText;
	public string questString;
	public bool isItemQuest;
	public string targetItem;
	public int numberOfItems;
	// Use this for initialization
	void Start () 
	{
		numberOfItems = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isItemQuest)
		{
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
	}

	public void StartQuest ()
	{
		questText.text = questString;
	}
	public void EndQuest ()
	{
		if (isItemQuest)
		{
			numberOfItems = 0;
		}
		questText.text = null;
		theQM.questCompleted[questNumber] = true;
		gameObject.SetActive(false);
	}
}
