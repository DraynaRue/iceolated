using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Logs : MonoBehaviour 
{
	 AudioSource audioLog;

	void Start(){
		audioLog = GetComponent<AudioSource>();
	}

	void OnTriggerStayS (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (Input.GetKeyDown (KeyCode.F)) 
			{
				Debug.Log ("In");
				audioLog.Play ();
				//Destroy (this.gameObject);
			}
		}
	}
}
