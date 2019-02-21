using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoBayDoor : MonoBehaviour {

	private Animation anim;

	void Start(){
		anim = GetComponent<Animation>();
	}

	public void OpenDoor(){
		anim["Door"].time = 2.2f;
	}
}
