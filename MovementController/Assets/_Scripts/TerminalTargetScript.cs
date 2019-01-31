using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalTargetScript : MonoBehaviour
{
	public Terminal hackedTerminal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hackedTerminal.success == true)
		{
			Destroy(this.gameObject);
		}
	}
}
