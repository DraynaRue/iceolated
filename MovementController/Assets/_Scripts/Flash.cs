using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour {

	public GameObject obj;
	public float speed;

	void Start(){
		InvokeRepeating("OnOff", 0.0f, speed);
	}

	void OnOff(){
		if(obj.activeInHierarchy){
			obj.SetActive(false);
		}else if(!obj.activeInHierarchy){
			obj.SetActive(true);
		}
	}
}
