using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Rigidbody rb;
	public GameObject player;

	void Start(){
		rb = GetComponent<Rigidbody>();
		player = GameObject.Find("_Player");
	}

	void Update(){
		Vector3 targetDir = player.transform.position - transform.position;

		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 4f, 0f);
		
		transform.rotation = Quaternion.LookRotation(newDir);


		rb.AddForce(targetDir, ForceMode.Force);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			PlayerHealth.health -= 10f;
			Destroy(this.gameObject);
		}	
		if(other.gameObject.tag == "Shield"){
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter(Collision collision){
		foreach (ContactPoint contact in collision.contacts)
        {
            Destroy(this.gameObject);
        }
	}
}
