using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObjective : MonoBehaviour {
	public int questNumber;
	public QuestManager theQM;
	public Text questText;
	public string questString;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void StartQuest ()
	{
		questText.text = questString;
	}
	public void EndQuest ()
	{
		questText.text = "";
		theQM.questCompleted[questNumber] = true;
		gameObject.SetActive(false);
	}
}
