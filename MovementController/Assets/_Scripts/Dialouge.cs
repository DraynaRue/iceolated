using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialouge : MonoBehaviour {

	public Text UIText;
	public GameObject part;
	public string currentPart;
	public float TimeToType = 3.0f;

	private float textPercentage = 0;
	private bool partActivated;
	private bool partFinished;
	
	private string part1 = "Error:// %P58!@'WS]# \n Captain's Log Hk{?NBn \n Good Man 8dI#]=*";
	private string part2 = "{AwxEWO$N+<#;Jh \n that keycard unlocks 2Na*'xwLO \n Return Gravity to 1%hT9";

	private string intro_MissionBrief = "A Pirate Mining Ship has crashed into an asteroid.\n We need you to enter the ship through the cargo bay and\n search for intel which can tell us more about this ship.\n Any survivors on the ship may be hostile so be careful!\n We also need you to deactivate the engines before they explode.\n Some areas of the ship may not be accessible on foot,\n so you must activate the teleportation system.\n Try checking the communications,\n see if they tried sending for help before they crashed.\n The AI core is corrupt but still active.\n Be aware.\n ~Captain.";

	public CAM cam;



	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Part1"){
			partActivated = true;
			currentPart = part1;
			Destroy(other.gameObject);
		} else if(other.gameObject.tag == "Part2"){
			partActivated = true;
			currentPart = part2;
			Destroy(other.gameObject);
		}
	}

	void FixedUpdate(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			part.SetActive(false);
		}

		if(partActivated){
			part.SetActive(true);
			int numberOfLettersToShow = (int)(currentPart.Length * textPercentage);
			UIText.text = currentPart.Substring(0, numberOfLettersToShow);
			textPercentage += Time.deltaTime / TimeToType;
			textPercentage = Mathf.Min(1.0f, textPercentage);
			if(numberOfLettersToShow == currentPart.Length){
				partFinished = true;				
				partActivated = false;
				currentPart="";
				textPercentage = 0f;
			}
			
		}
	}
}
