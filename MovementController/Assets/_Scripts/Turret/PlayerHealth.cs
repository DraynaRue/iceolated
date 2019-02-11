using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public static float health = 100f;

	void Update(){
		//Debug.Log(health);
		if(health <= 0){
			Debug.Log("Player Dead");
		}
	}
}
