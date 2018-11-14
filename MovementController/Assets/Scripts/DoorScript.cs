using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
	public GameObject key;

	protected Animator _ani;
	
	// Use this for initialization
	void Start () {
		_ani = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other) {
		if (other.collider.tag == "Player")
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

	private void OnCollisionExit(Collision other) {
		_ani.SetTrigger("Close");
	}
}
