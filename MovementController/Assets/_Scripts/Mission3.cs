using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission3 : MonoBehaviour {

	public GameObject turrets;
	public GameObject pos1, pos2;
	public bool mission3 = false;

	public float currentProgress = 0.0f;

	void Update(){
		if(mission3 == true){
			turrets.transform.position = Vector3.Lerp(pos1.transform.position, pos2.transform.position,currentProgress / 1.0f);
			currentProgress += Time.deltaTime;
		}
		if(turrets.transform.position == pos2.transform.position){
			Destroy(this.gameObject);
		}
	}
	public void Mission3Start(){
		turrets.SetActive(true);
		mission3 = true;
	}
}
