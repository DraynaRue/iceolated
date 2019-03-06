using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSightS : MonoBehaviour 
{

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			AudioManager.Instance.PlaySound ("Drone_Found", transform.position);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			AudioManager.Instance.PlaySound ("Drone_Seaching", transform.position);
		}
	}
}
