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
