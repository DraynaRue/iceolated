using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalTargetScript : MonoBehaviour
{
	public TerminalController server;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (server.success == true)
		{
			Destroy(this.gameObject);
		}
	}
}
