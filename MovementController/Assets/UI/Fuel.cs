using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
	public GameObject fuelGage;
	public GameObject player;
	public float fuelPercentage = 100f;

	public bool isOutOfFuel = false;
	public Animator animator;

	void Start()
	{
		animator.Play("fuel", -1, fuelPercentage);
	}

	void Update()
	{
		// Checks if zero gravity mode is enabled
		if (player.GetComponent<MovementScript>().isZeroGravity == true)
		{
			// Checks to see if the 'jetpack' is being used
			if(Input.GetAxis("Horizontal") != 0 && fuelPercentage > 0 || Input.GetAxis("Vertical") != 0 && fuelPercentage > 0 || Input.GetAxis("Jump") != 0 && fuelPercentage > 0 || Input.GetAxis("Crouch") != 0 && fuelPercentage > 0 )
			{
				fuelPercentage -= 2.5f * Time.deltaTime;
				animator.Play("fuel", -1, (1f / 100) * fuelPercentage);
			}
		}
		else
		{
			animator.speed = 0f;
		}

		// Sets isOutOfFuel to true if fuelPercentage is at 0
		if (fuelPercentage <= 0)
		{
			isOutOfFuel = true;
		}
	}
}