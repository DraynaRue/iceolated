using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	public GameObject shield;
	public Animation gun;

	void Update () {
			if(Input.GetMouseButton(2)) {
				shield.gameObject.SetActive(true);
			}else {shield.gameObject.SetActive(false);}
		}
	}
