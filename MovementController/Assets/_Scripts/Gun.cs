using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour 
{

	public GameObject laser;
	public Animation gun;
	Turret turret;
	public Text hitPoint;
	public Fuel fuelHolder;
	

	public static bool isShooting = false;

	void Start(){
		fuelHolder.GetComponent<Fuel>();
	}
	void FixedUpdate () 
	{
		RaycastHit hit;

	

		if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)) 
		{
			if(hit.transform.gameObject.tag == "Ice" && Input.GetMouseButton(0) && fuelHolder.fuelPercentage > 1) 
			{
				gun["Take 001"].speed = 10f;
				//Debug.Log("ok hit ice");
				laser.gameObject.SetActive(true);
				hit.transform.localScale -= Vector3.one * Time.deltaTime * 250f;
				if (hit.transform.localScale.x <= 0.00f)
				{
					Destroy(hit.transform.gameObject);
				}
			} else if(hit.transform.gameObject.tag == "Turret" && Input.GetMouseButton(0) && fuelHolder.fuelPercentage > 1){
				gun["Take 001"].speed = 10f;
				//Debug.Log("ok hit turret");
				laser.gameObject.SetActive(true);
				turret = hit.transform.gameObject.GetComponent<Turret>();
				
				Text hitPoints;
				Transform spawn = hit.transform.GetChild(1);
				hitPoints = Instantiate(hitPoint, spawn.position, Quaternion.identity);
				hitPoints.transform.SetParent(spawn.transform);
				hitPoints.transform.localScale = new Vector3(1,1,1);
				float dmg = Random.Range(0f, 1f);
				hitPoint.text = dmg.ToString();
				turret.Take_Damage(dmg); 
				
			}
			else 
			{
				gun["Take 001"].speed = 1f;
				laser.gameObject.SetActive(false);
			}

		if(Input.GetMouseButton(0) && fuelHolder.fuelPercentage > 1){
			isShooting = true;
			gun["Take 001"].speed = 10f;
			laser.gameObject.SetActive(true);
		}else{
			isShooting = false;
			gun["Take 001"].speed = 1f;
			laser.gameObject.SetActive(false);
		}
		}
	}
}
