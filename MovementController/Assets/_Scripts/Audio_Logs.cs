using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Logs : MonoBehaviour 
{
	AudioSource audioLog;
	public GameObject Log_Audio;
	public Animator anim;
	public float timer;

	void Start(){
		audioLog = Log_Audio.GetComponent<AudioSource>();
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			timer -= Time.deltaTime;
			if (Input.GetKeyDown (KeyCode.F)) 
			{
				audioLog.Play ();
				anim.SetTrigger ("isOn");
				//Destroy (this.gameObject);
			}
			if (timer <= 0)
				{
				anim.SetTrigger ("isOFF");
				Destroy (this.gameObject);
				}
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			anim.SetTrigger ("isOFF");
			Destroy (this.gameObject);
		}
	}
}
