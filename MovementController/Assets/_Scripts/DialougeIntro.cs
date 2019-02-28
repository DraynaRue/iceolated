using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialougeIntro : MonoBehaviour {

	public TextMeshProUGUI UIText;
	public GameObject part;
	public string currentPart;
	public float TimeToType = 3.0f;

	private float textPercentage = 0;
	private bool partActivated;
	private bool partFinished;

	private string intro_MissionBrief = "A Pirate Mining Ship has crashed into an asteroid.\n We need you to enter the ship through the cargo bay and \n search for intel which can tell us more about this ship.\n Any survivors on the ship may be hostile so be careful!\n We also need you to deactivate the engines before they explode.\n Some areas of the ship may not be accessible on foot,\n so you must activate the teleportation system.\n Try checking the communications,\n see if they tried sending for help before they crashed.\n The AI core is corrupt but still active.\n Be aware.\n ~Captain.";

	public CAM cam;
	private bool doneDialog = false;

	void Start(){
		cam = this.GetComponent<CAM>();
	}

	public void GO(){
			partActivated = true;
			currentPart = intro_MissionBrief;
			StartCoroutine(finshing());
		}

	void FixedUpdate(){
		if(Input.GetKeyDown(KeyCode.Return)){
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

	IEnumerator finshing(){
		yield return new WaitForSeconds(TimeToType);
		cam.EndOfCutScene();
	}
}
