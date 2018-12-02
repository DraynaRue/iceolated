using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {



	public float percentage = 100f;

	GameObject DoorA_High;
	Animation Door;
	public bool opening;

	void Start(){
		DoorA_High = this.gameObject;
		Door = DoorA_High.GetComponent<Animation>();
	}

	void Update(){
		if(opening){
			Door.Play("Door");
		} 
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			opening = true;
		}
	}
}