using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour {

	public GameObject Player;
	public GameObject TargetPad;
	public float VerticalOffset;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Interact ()
	{
		Vector3 newPos = new Vector3 (TargetPad.transform.position.x, TargetPad.transform.position.y + VerticalOffset, TargetPad.transform.position.z);
		Player.transform.SetPositionAndRotation(newPos, Player.transform.rotation);
	}
}
