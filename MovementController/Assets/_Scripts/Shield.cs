using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	public GameObject shield;
	public static bool isShielding = false;
	public Fuel fuelHolder;

		void Start(){
		fuelHolder.GetComponent<Fuel>();
	}
	
	void Update () {
		if(Input.GetKey(KeyCode.Mouse2) && fuelHolder.fuelPercentage > 1){
			shield.gameObject.SetActive(true);
			isShielding = true;
		} else{shield.gameObject.SetActive(false);
		isShielding = false;}
	}
}
