using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityReturns : MonoBehaviour {

	void Update () {
		if(GravityControlScript.GR == true){
			if(this.gameObject.GetComponent<Rigidbody>().useGravity == false)
				this.gameObject.GetComponent<Rigidbody>().useGravity = true;
		} 
		else if(GravityControlScript.GR == false){
			if(this.gameObject.GetComponent<Rigidbody>().useGravity == true)
				this.gameObject.GetComponent<Rigidbody>().useGravity = false;
		}
	}
}
