using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TPInteract : MonoBehaviour {
	public GameObject firstHalf, secondHalf; //ship halves
	public bool inTP1, inTP2, inTP3, inTP4;
	public TeleporterScript1 tpScript1;
	public TeleporterScript2 tpScript2;
	public TeleporterScript3 tpScript3;
	public TeleporterScript4 tpScript4;


	void Start(){
		tpScript1 = (TeleporterScript1)FindObjectOfType<TeleporterScript1>();
		tpScript2 = (TeleporterScript2)FindObjectOfType<TeleporterScript2>();
		tpScript3 = (TeleporterScript3)FindObjectOfType<TeleporterScript3>();
		tpScript4 = (TeleporterScript4)FindObjectOfType<TeleporterScript4>();

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
		if(other.gameObject.tag == "TP3"){
			inTP3 = true;
		}
		if(other.gameObject.tag == "TP4"){
			inTP4 = true;
		}
	}
	void OnTriggerExit(Collider other){
		
		if(other.gameObject.tag == "TP1"){
			inTP1 = false;
		}
		if(other.gameObject.tag == "TP2"){
			inTP2 = false;
		}
		if(other.gameObject.tag == "TP3"){
			inTP3 = false;
		}
		if(other.gameObject.tag == "TP4"){
			inTP4 = false;
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

		if(inTP3 == true && Input.GetKeyDown(KeyCode.E)){
			tpScript3.Interact();
			firstHalf.SetActive(false);
			secondHalf.SetActive(true);
		}
		if(inTP4 == true && Input.GetKeyDown(KeyCode.E)){
			tpScript4.Interact();
			firstHalf.SetActive(false);
			secondHalf.SetActive(true);
		}
	}
}
