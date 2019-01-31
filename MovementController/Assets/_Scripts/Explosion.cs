using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public float radius, power;

	void Start () {
		Vector3 pos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(pos, radius);

        foreach (Collider hit in colliders){
            Rigidbody rb = hit.GetComponent<Rigidbody>();
			
            if (rb != null)
                rb.AddExplosionForce(power, pos, radius, 3.0F);
        }
    }
}
