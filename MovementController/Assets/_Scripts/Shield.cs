using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	public GameObject shield;
	
	void Update () {
		if(Input.GetKey(KeyCode.Mouse2)){
			shield.gameObject.SetActive(true);
		} else{shield.gameObject.SetActive(false);}
	}
}
