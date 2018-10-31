using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour {

	public GameObject UIElement;
	public GameObject Player;

	// Use this for initialization
	void Start () {
		UIElement.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Player")
		{
			UIElement.SetActive(true);
		}
	}

	private void OnTriggerStay(Collider other) {
		if (other.tag == "Player")
		{
			if (this.GetComponent<KeyScript>() != null && Input.GetButton("Interact") == true)
			{
				GetComponent<KeyScript>().Interact();
				UIElement.SetActive(false);
			}
		}
	}
}
