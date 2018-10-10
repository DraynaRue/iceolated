using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControlScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == "Player")
		{
			other.collider.GetComponent<MovementScript>().isZeroGravity = !other.collider.GetComponent<MovementScript>().isZeroGravity;
			other.collider.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		}
	}
}
