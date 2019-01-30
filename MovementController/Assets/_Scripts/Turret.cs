using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public Transform target;



	void Update(){
		Vector3 targetDir = target.position - transform.position;

		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 4f, 0f);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);

		
	}
}
