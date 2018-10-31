using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLogScript : MonoBehaviour {

	public AudioClip AudioLog;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Interact ()
	{
		AudioLog.LoadAudioData();
	}
}
