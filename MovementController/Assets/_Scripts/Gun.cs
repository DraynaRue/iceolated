using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour 
{

	public GameObject laser, iceBreakParticle;
	public Animation gun;
	Turret turret;
	public Text hitPoint;
	public Fuel fuelHolder;

	public static bool isShooting = false;
	public static bool isMeltingIce = false;
	
	void Start(){
		fuelHolder.GetComponent<Fuel>();
	}
	void FixedUpdate () 
	{
		RaycastHit hit;

		if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)) 
		{
			if(hit.rigidbody && Input.GetMouseButton(0) && fuelHolder.fuelPercentage > 1){
				hit.rigidbody.AddForce(transform.forward * 25f);
			}
			else if(hit.transform.gameObject.tag == "Ice" && Input.GetMouseButton(0) && fuelHolder.fuelPercentage > 1) 
			{
				isMeltingIce = true;
				gun["Take 001"].speed = 10f;
				//Debug.Log("ok hit ice");
				laser.gameObject.SetActive(true);
				//hit.transform.localScale -= Vector3.one * Time.deltaTime * 500f;
				Renderer rend;
				Color oldCol;
				Color newCol;
				float currentProgress;
				rend = hit.transform.gameObject.GetComponent<Renderer>();
				oldCol = rend.material.color;
				newCol = Color.red;
				currentProgress = hit.transform.gameObject.GetComponent<IceScript>().currentProgress;

				rend.material.SetColor("_EmissionColor", Color.Lerp(oldCol, newCol, currentProgress / 0.5f) * Mathf.Lerp(0.8457f, 10.0f, currentProgress / 1.0f));
				hit.transform.gameObject.GetComponent<IceScript>().currentProgress = currentProgress += Time.deltaTime;

				if (currentProgress >= 1.0f)
				{
					Instantiate(iceBreakParticle, hit.transform.position, Quaternion.identity);
					Destroy(hit.transform.gameObject);
				}
			} 
			else if(hit.transform.gameObject.tag == "Turret" && Input.GetMouseButton(0) && fuelHolder.fuelPercentage > 1)
			{
				isMeltingIce = false;
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
			else if(Input.GetMouseButton(0) && fuelHolder.fuelPercentage > 1)
			{
				isMeltingIce = false;
				isShooting = true;
				gun["Take 001"].speed = 10f;
				laser.gameObject.SetActive(true);
			}
			else
			{
				isMeltingIce = false;
				isShooting = false;
				gun["Take 001"].speed = 1f;
				laser.gameObject.SetActive(false);
			}
		}
	}
}
