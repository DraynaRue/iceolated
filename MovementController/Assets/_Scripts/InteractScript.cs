﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour {

	public GameObject InteractUI;
	public GameObject Player;

	// Use this for initialization
	void Start ()
	{
		InteractUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			InteractUI.SetActive(true);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			if (this.GetComponent<KeyScript>() != null && Input.GetButton("Interact") == true)
			{
				GetComponent<KeyScript>().Interact();
				InteractUI.SetActive(false);
			}
			else if (this.GetComponent<AudioLogScript>() != null && Input.GetButton("Interact") == true)
			{
				GetComponent<AudioLogScript>().Interact();
				InteractUI.SetActive(false);
			}
		}
	}
}
