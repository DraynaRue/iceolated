﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public static float health = 100f;
	public Text tHealth;
	public Slider sHealth;

	void Update(){
		tHealth.text = health.ToString() + " / 100";
		sHealth.value = health;
				
		if(health <= 0){
			SceneManager.LoadScene("MainMenu");
		}
	}
}
