using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingSrairs : MonoBehaviour {

	public GameObject tpIn, tpOut, cam;
	bool inLoop = false;

	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Loop1.1"){
			if(inLoop)
				cam.transform.rotation *= Quaternion.Euler(0,180f,0);
			
			inLoop = true;
			transform.position = tpIn.transform.position;
			
		}

		if(other.gameObject.tag == "Loop1.2"){
			//cam.transform.rotation *= Quaternion.Euler(0,180f,0);
			transform.position = tpOut.transform.position;
			inLoop = false;
		}
	}
}
