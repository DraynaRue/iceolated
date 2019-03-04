using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Logs : MonoBehaviour 
{
	 AudioSource audioLog;
	 public GameObject Log_Audio;

	void Start(){
		audioLog = Log_Audio.GetComponent<AudioSource>();
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (Input.GetKeyDown (KeyCode.F)) 
			{
				Debug.Log ("In");
				audioLog.Play ();
				Destroy (this.gameObject);
			}
		}
	}
}
