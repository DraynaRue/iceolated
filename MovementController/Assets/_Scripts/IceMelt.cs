﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMelt : MonoBehaviour 
{

	public GameObject laser;
	public Animation gun;

	void Update () 
	{
		RaycastHit hit;

		if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)) 
		{
			if(hit.transform.gameObject.tag == "Ice" && Input.GetMouseButton(0)) 
			{
				gun["Take 001"].speed = 10f;
				Debug.Log("ok hit ice");
				laser.gameObject.SetActive(true);
				hit.transform.localScale -= Vector3.right * Time.deltaTime * 0.1f;
				if (hit.transform.localScale.x <= 0.00f)
				{
					Destroy(hit.transform.gameObject);
				}
			}

			if(hit.transform.gameObject.tag == "turret"){
				Turret.turretHealth -= 5f * Time.deltaTime;
			}
			else 
			{
				gun["Take 001"].speed = 1f;
				laser.gameObject.SetActive(false);
			}
		}
	}
}
