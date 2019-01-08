using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMelt : MonoBehaviour 
{

	public GameObject laser;

	void Update () 
	{
		RaycastHit hit;

		if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)) 
		{
			if(hit.transform.gameObject.tag == "Ice" && Input.GetKey(KeyCode.F)) 
			{
				Debug.Log("ok hit ice");
				laser.gameObject.SetActive(true);
				hit.transform.localScale -= Vector3.right * Time.deltaTime * 0.1f;
				if (hit.transform.localScale.x <= 0.00f)
				{
					Destroy(hit.transform.gameObject);
				}
			} 
			else 
			{
				laser.gameObject.SetActive(false);
			}
		}
	}
}
