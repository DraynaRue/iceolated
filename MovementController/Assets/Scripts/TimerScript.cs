using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class TimerScript : MonoBehaviour
{
	public static float timeLeft = 60f;
	public Text countdown;
	public GameObject timerObj;
	public bool TimerTrigger;


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
				Debug.Log("Engines Blew Up!");
			}

			
		}
	}
}