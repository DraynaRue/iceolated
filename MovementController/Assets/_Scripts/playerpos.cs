using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerpos : MonoBehaviour {
 
	public GameObject playerStart;
	public GameObject canteenPos;
	public bool playerstart;
	public bool canteen;
	void Start () {
		if(playerstart){
			this.transform.position = playerStart.transform.position;
		}
		if(canteen){
			this.transform.position = canteenPos.transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
