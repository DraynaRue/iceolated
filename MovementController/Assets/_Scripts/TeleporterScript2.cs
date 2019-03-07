using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript2 : MonoBehaviour {

	public GameObject Player;
	public GameObject TargetPad;
	public float VerticalOffset;
	
	public void Interact(){
		Vector3 newPos = new Vector3 (TargetPad.transform.position.x, TargetPad.transform.position.y + VerticalOffset, TargetPad.transform.position.z);
		Player.transform.SetPositionAndRotation(newPos, Player.transform.rotation);
	}
}
