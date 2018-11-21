﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
	public GameObject key;
	protected Vector3 startPos;
	protected Vector3 endPos;
	
	// Use this for initialization
	void Start () {
		startPos = GetComponent<Rigidbody>().transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Player")
		{
			if (other.gameObject.GetComponent<InventoryScript>().inv.Contains(this.key))
			{
				_ani.SetTrigger("Open");
				//Destroy(this.gameObject);
				//other.gameObject.GetComponent<InventoryScript>().inv.Remove(this.key);
				//Destroy(key.gameObject);
			}
		}
	}

	private void OnTriggerExit(Collider other) {
		_ani.SetTrigger("Close");
	}
}
