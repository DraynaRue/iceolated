using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TPInteract : MonoBehaviour {
	public GameObject firstHalf, secondHalf; //ship halves
	public bool inTP1, inTP2;
	public TeleporterScript1 tpScript1;
	public TeleporterScript2 tpScript2;


	void Start(){
		tpScript1 = (TeleporterScript1)FindObjectOfType<TeleporterScript1>();
		tpScript2 = (TeleporterScript2)FindObjectOfType<TeleporterScript2>();

		firstHalf.SetActive(true);
		secondHalf.SetActive(false);
	}
	void OnTriggerEnter(Collider other){
		
		if(other.gameObject.tag == "TP1"){
			inTP1 = true;
		}
		if(other.gameObject.tag == "TP2"){
			inTP2 = true;
		}
	}
	void OnTriggerExit(Collider other){
		
		if(other.gameObject.tag == "TP1"){
			inTP1 = false;
		}
		if(other.gameObject.tag == "TP2"){
			inTP2 = false;
		}
	}

	void Update(){
		if(inTP1 == true && Input.GetKeyDown(KeyCode.E)){
			tpScript1.Interact();
			firstHalf.SetActive(false);
			secondHalf.SetActive(true);
		}
		
		if(inTP2 == true && Input.GetKeyDown(KeyCode.E)){
			tpScript2.Interact();
			firstHalf.SetActive(true);
			secondHalf.SetActive(false);
		}
	}
}
