using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POD : MonoBehaviour {
	public GameObject pos1, pos2;
	float t;
	float timetoreach = 8f;
	
	void Start(){

	}

	void Update (){
		t += Time.deltaTime / timetoreach;

		transform.position = Vector3.Lerp(pos1.transform.position, pos2.transform.position, t);
	}
}