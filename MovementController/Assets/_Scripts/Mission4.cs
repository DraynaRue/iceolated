 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission4 : MonoBehaviour {
	private QuestManagerIntel theQM;
	public int questNumber;
	public bool startQuest;
	public bool endQuest;
	public bool mission4Started = false; 

	void Start(){
		theQM = FindObjectOfType<QuestManagerIntel>();
	}

	void Update () {
		if(mission4Started == true){
			//Do something
		}
	}

	public void Mission4Start(){
		Debug.Log("MISSION 4");
		mission4Started = true;
		if (!theQM.questCompleted[questNumber])
			{
				if (startQuest && !theQM.quests[questNumber].gameObject.activeSelf)
				{
					theQM.quests[questNumber].gameObject.SetActive(true);
					theQM.quests[questNumber].StartQuest();
				}
				if (endQuest && theQM.quests[questNumber].gameObject.activeSelf)
				{
					theQM.quests[questNumber].EndQuest();
				}
			}
	}
}
