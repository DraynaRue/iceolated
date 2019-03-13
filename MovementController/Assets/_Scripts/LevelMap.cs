using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMap : MonoBehaviour {

	public GameObject map;
	public bool mapObtained = false;

	void Update () {
		if(Input.GetKeyDown(KeyCode.M) && mapObtained == true){
			map.SetActive(true);
		}
	}

	public void ObtainMap(){
		mapObtained = true;
	}
}
