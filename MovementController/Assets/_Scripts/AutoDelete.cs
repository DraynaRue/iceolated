using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDelete : MonoBehaviour {

	public float timeToDie;

	void Update () {
		timeToDie -= 1 *  Time.deltaTime;

		if(timeToDie <= 0.0f){
			Destroy(this.gameObject);
		}
	}
}
