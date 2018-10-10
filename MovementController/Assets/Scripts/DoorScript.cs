using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
	public GameObject key;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other) {
		if (other.collider.tag == "Player")
		{
			if (other.gameObject.GetComponent<InventoryScript>().inv.Contains(this.key))
			{
				Destroy(this.gameObject);
				//other.gameObject.GetComponent<InventoryScript>().inv.Remove(this.key);
				//Destroy(key.gameObject);
			}
		}
	}
}
