using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terminal : MonoBehaviour {

	public GameObject terminalInterface;
	public CameraScript camScript;
	public GameObject player;
	public Text A1, A2, A3, A4, A5, A6, A7, A8, A9, A10,
				B1, B2, B3, B4, B5, B6, B7, B8, B9, B10,
				C1, C2, C3, C4, C5, C6, C7, C8, C9, C10;

	public string 	twist, aware, mayor, swarm, smell, video,
	 			 	blast, shave, youth, peace, shift, donor, awful, tough,
	  				hobby, wheel, style, tight, drown, abuse, stick, sweet,
	  				elect, brave, split, crime, clerk, penny, tribe, pound;

	void Start(){
		player = GameObject.FindGameObjectWithTag("MainCamera");
		camScript = player.GetComponent<CameraScript>();
	}
	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Return)){
			terminalInterface.SetActive(true);
			camScript.enabled = false;
			Cursor.lockState = CursorLockMode.None;	
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player"){
			terminalInterface.SetActive(false);
			camScript.enabled = true;
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}	
}
