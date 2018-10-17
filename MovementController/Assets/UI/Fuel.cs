using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{

	public GameObject fuelGage;
	public float fuelPercentage = 100f;
	public Animator animator;

	void Start()
	{
		animator.Play("fuel", -1, fuelPercentage);
	}

	void Update()
	{
		if (GetComponent<MovementScript>().isZeroGravity == true)
		{
			if(Input.GetKey(KeyCode.Space) && fuelPercentage > 0)
			{
				fuelPercentage -= 2.5f * Time.deltaTime;
				animator.Play("fuel", -1, (1f / 100) * fuelPercentage);
			}
		}
		else
		{
			animator.speed = 0f;
		}
	}
}