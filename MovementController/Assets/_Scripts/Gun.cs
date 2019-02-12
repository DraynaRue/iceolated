using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour 
{

	public GameObject laser;
	public Animation gun;
	Turret turret;

	void Update () 
	{
		RaycastHit hit;

		if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)) 
		{
			if(hit.transform.gameObject.tag == "Ice" && Input.GetMouseButton(0)) 
			{
				gun["Take 001"].speed = 10f;
				Debug.Log("ok hit ice");
				laser.gameObject.SetActive(true);
				hit.transform.localScale -= Vector3.one * Time.deltaTime * 2000f;
				if (hit.transform.localScale.x <= 0.00f)
				{
					Destroy(hit.transform.gameObject);
				}
			} else if(hit.transform.gameObject.tag == "Turret" && Input.GetMouseButton(0)){
				gun["Take 001"].speed = 10f;
				Debug.Log("ok hit turret");
				laser.gameObject.SetActive(true);
				turret = hit.transform.gameObject.GetComponent<Turret>();
				turret.Take_Damage(1f);
			}
			else 
			{
				gun["Take 001"].speed = 1f;
				laser.gameObject.SetActive(false);
			}
		}
	}
}
