using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody>();
	}

	void Update(){
		rb.AddForce(Vector3.forward, ForceMode.Force);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			PlayerHealth.health -= 10f;
			
		}		
	}
}
