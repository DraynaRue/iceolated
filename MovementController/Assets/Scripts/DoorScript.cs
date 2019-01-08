using System.Collections;
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

	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player")
		{
			if (other.gameObject.GetComponent<InventoryScript>().inv.Contains(this.key))
			{
				Destroy(this.gameObject);
			}
		}
	}
}
