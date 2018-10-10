using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")	
		{
			if (other.gameObject.GetComponent<InventoryScript>() != null)
			{
				other.gameObject.GetComponent<InventoryScript>().inv.Add(this.gameObject);
				this.gameObject.SetActive(false);
			}
		}
	}
}
