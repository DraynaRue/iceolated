﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
	public static float timeLeft = 80f;
	public Text countdown;
	public GameObject timerObj;
	public static bool TimerTrigger;

	void Start(){
		timeLeft = 160f;
		TimerTrigger = false;
		timerObj.SetActive(false);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			TimerTrigger = true;
		}
	}
	
	void Update(){
		if(TimerTrigger){
			timerObj.SetActive(true);
			countdown.text = "" + timeLeft.ToString();
			timeLeft -= 1 * Time.deltaTime;

			if(timeLeft <= 0){
                SceneManager.LoadScene("Death");
			}
			if(!TimerTrigger){
				timerObj.SetActive(false);
			}

			
		}
	}
}