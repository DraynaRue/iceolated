using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

	private Animation anim;

	void Start(){
		anim = GetComponent<Animation>();
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			anim.Play("Door");
			StartCoroutine(OpenDoor());
		}
	}

	IEnumerator OpenDoor(){
		yield return new WaitForSeconds(2.2f);
		anim["Door"].time = 2.2f;
	}
}
