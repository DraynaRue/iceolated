using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Logs : MonoBehaviour 
{
	AudioSource audioLog;
	public GameObject Log_Audio;
	public Animator anim;
	public float timer;
	public GameObject interactUI;
 
	private bool started = false;

	void Start(){
		audioLog = Log_Audio.GetComponent<AudioSource>();
	}

	void Update(){
		if (timer <= 0)
			{
				anim.SetTrigger ("isOFF");
				Destroy (this.gameObject);
		}

		if(started)
			timer -= Time.deltaTime;
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player")
		{
			interactUI.SetActive(true);
		}
	}

		void OnTriggerExit(Collider other) 
	{
		if (other.tag == "Player")
		{
			interactUI.SetActive(false);
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			
			if (Input.GetAxis("Interact") > 0) 
			{
				audioLog.Play ();
				anim.SetTrigger ("isOn");
				started = true;
			}

		}
	}
}
