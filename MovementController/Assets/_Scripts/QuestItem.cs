using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour 
{
	public int questNumber;
	public QuestManagerIntel theQM;
	public string itemName;

	private bool got = false;
	// Use this for initialization
	void Start () 
	{
		theQM = FindObjectOfType<QuestManagerIntel>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	private void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.name == "_Player")
		{
			if (!theQM.questCompleted[questNumber] && theQM.quests[questNumber].gameObject.activeSelf && got == false && Input.GetKeyDown(KeyCode.F))
			{
				theQM.itemCollected = itemName;
				got = true;
			}
		}	
	}
}
