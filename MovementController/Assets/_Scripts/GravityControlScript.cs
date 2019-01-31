using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControlScript : MonoBehaviour
{
	public MovementScript movScript;
	public GameObject player;
	public static bool GR = false;
	public Terminal hackedTerminal;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		movScript = player.GetComponent<MovementScript>();
	}

	void Update()
	{
		if (hackedTerminal.success == true)
		{	
			movScript.isZeroGravity = false;
			GR = true;
		}
	}
}
