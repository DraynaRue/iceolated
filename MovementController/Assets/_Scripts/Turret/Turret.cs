using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{

	public Transform target;
	public GameObject bullet;
	private bool isShooting = false;
	public GameObject spawn, spawnL, spawnR;

	public float turretHealth = 100f;

	private int leftNotRight;

	public Text tHealth;
	public Slider sHealth;


	void Update()
	{
		tHealth.text = turretHealth.ToString() + " / 100";
		sHealth.value = turretHealth;

		Vector3 targetDir = target.position - transform.position;

		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 4f, 0f);
		
		transform.rotation = Quaternion.LookRotation(newDir);

		RaycastHit hit;

		if(Physics.Raycast(spawn.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)) 
		{
			if(hit.transform.gameObject.tag == "Player" && isShooting == false){
				StartCoroutine(SHOOTING());			
			}
		}

		if(turretHealth <= 0f)
		{
			AudioManager.Instance.PlaySound("Enemy_Damage", transform.position);
			Destroy(this.gameObject);
		}
	}

	public void Take_Damage(float amount)
	{
		turretHealth -= amount;
	}

	IEnumerator SHOOTING ()
	{
		isShooting = true;
		Instantiate(bullet, spawnL.transform.position, Quaternion.identity);
		Instantiate(bullet, spawnR.transform.position, Quaternion.identity);
		yield return new WaitForSeconds(1f);
		isShooting = false;
	}
}
