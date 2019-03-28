using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneScript : MonoBehaviour 
{
	public float droneHealth = 100f;
	public Text tHealth;
	public Slider sHealth;
	public GameObject Target;
	public float SightDistance;
	public float HoverHeight;
	public float VerticalSpeed;
	public float HorizonalSpeed;

	// Use this for initialization
	void Start()
	{
		Target = GameObject.Find("_Player");
		tHealth = GetComponentInChildren<Text>();
		sHealth = GetComponentInChildren<Slider>();
	}

	// Update is called once per frame
	void Update ()
	{
		Hover();

		tHealth.text = droneHealth.ToString() + " / 100";
		sHealth.value = droneHealth;

		if(droneHealth <= 0f)
		{
			Destroy(this.gameObject);
            AudioManager.Instance.PlaySound("Enemy_Damage", transform.position);
		}

		Vector3 targetDir = Target.transform.position - transform.position;
		float angle = Vector3.Angle(targetDir, transform.forward);
		float dist = Vector3.Distance(Target.transform.position, transform.position);
		if (angle <= 60.0f && dist <= SightDistance) 
		{
			Quaternion rot = Quaternion.LookRotation(targetDir, Vector3.up);
			rot.x = 0;
			rot.z = 0;
			transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 10f);

			RaycastHit hit;
			Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
			if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
			{
				float bufferDist = 0.5f;
			//	if (hit.distance >= bufferDist - 0.01f && hit.distance <= bufferDist + 0.01f)
			//	{
					// Stops jittering
			//	}
				if (hit.distance <= bufferDist)
				{
					transform.position += transform.forward * -HorizonalSpeed;
					//found.Play(0);

				}
				else
				{
					transform.position += transform.forward * HorizonalSpeed;
					//search.Play (0);
				}
			}
		}
	}

	void Hover ()
	{
		RaycastHit hit;
		Debug.DrawRay(transform.position, Vector3.down * 10, Color.red);
		if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
		{
			if (hit.distance >= HoverHeight - 0.01f && hit.distance <= HoverHeight + 0.01f)
			{
				//stops jittering
			}
			else if (hit.distance <= HoverHeight)
			{
				transform.position += Vector3.up * VerticalSpeed;
			}
			else if (hit.distance >= HoverHeight)
			{
				transform.position += Vector3.up * -VerticalSpeed;
			}
		}
	}
	public void Take_Damage(float damageValue)
	{
		droneHealth--;
	}
}
