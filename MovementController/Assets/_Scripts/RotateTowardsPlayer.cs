using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetDir = target.transform.position - transform.position;

		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 1f, 0f);
		
		transform.rotation = Quaternion.LookRotation(newDir);
	}
}
