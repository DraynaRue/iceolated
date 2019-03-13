using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Logs : MonoBehaviour 
{
	AudioSource audioLog;
	public GameObject Log_Audio;
	public Animator anim;
	public float timer;
 
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

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			
			if (Input.GetKeyDown (KeyCode.F)) 
			{
				audioLog.Play ();
				anim.SetTrigger ("isOn");
				started = true;
			}

		}
	}

}
