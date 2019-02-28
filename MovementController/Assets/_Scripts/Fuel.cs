using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour {

	public GameObject fuelGage;
	public float fuelPercentage = 100f;
	public Animator animator;

	void Start(){
		animator.Play("fuel", -1, fuelPercentage);
	}

	void FixedUpdate(){

		if(fuelPercentage >= 100f){
			fuelPercentage = 100f;
		}

		if( GetComponent<MovementScript>().isZeroGravity == true && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.S)) && fuelPercentage > 0){
			fuelPercentage -= 3f * Time.deltaTime;
			animator.Play("fuel", -1, (1f / 100) * fuelPercentage);
		}else if(Gun.isShooting){
			fuelPercentage -= 3f * Time.deltaTime;
			animator.Play("fuel", -1, (1f / 100) * fuelPercentage);
		}else if(Shield.isShielding){
			fuelPercentage -= 3f * Time.deltaTime;
			animator.Play("fuel", -1, (1f / 100) * fuelPercentage);
		}else{
			//animator.speed = 0f;
			animator.Play("fuel", -1, (1f / 100) * fuelPercentage);
			fuelPercentage += 1.5f * Time.deltaTime;
		}
			
	}
}
