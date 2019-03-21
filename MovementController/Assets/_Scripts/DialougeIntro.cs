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

	private string intro_MissionBrief = "Your mission as Chief Science Officer is to enter and search the crashed pirate mining ship. \n Once you've accessed the ship through the Cargo Bay, you must gather intel in order to understand why the ship \n crashed and what happened to the crew. We've detected movement inside but no living life forms. \n We are also detecting extreme toxisity in parts of the ship so be careful where you tread. \n I'll be watching you and observing the status of the ship. \n Your first objective will be to disable both engines before they overheat and explode. \n Time is running out, act fast. \n ~Captain.";

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
