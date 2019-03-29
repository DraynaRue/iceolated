using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public static float health = 100f;
	public Text tHealth;
	public Slider sHealth;

	void Start(){
		health = 100;
	}
	void Update(){
		tHealth.text = health.ToString("F1") + " / 100";
		sHealth.value = health;

		if(health < 100)
			health += 1f * Time.deltaTime;
				
		if(health <= 0){
			SceneManager.LoadScene("Death_Scene");
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Ice"){
			health -= 5f;
		}
	}
}
