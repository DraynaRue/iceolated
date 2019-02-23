using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoBayDoor : MonoBehaviour {

	public DoorScript doorscript;

	void Start(){
		doorscript = this.GetComponent<DoorScript>();
		doorscript.enabled = false;
	}
	public void OpenDoor(){
		doorscript.enabled = true;
	}

}