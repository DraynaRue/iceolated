using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControlScript : MonoBehaviour {

	public static bool GR = false;

	void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == "Player")
		{	
			if(GR == false){
				other.collider.GetComponent<MovementScript>().isZeroGravity = !other.collider.GetComponent<MovementScript>().isZeroGravity;
				other.collider.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
				GR = true;
			} else if(GR == true){
				other.collider.GetComponent<MovementScript>().isZeroGravity = !other.collider.GetComponent<MovementScript>().isZeroGravity;
				other.collider.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
				GR = false;
			}
		}
	}
}
