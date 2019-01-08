using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class TimerScript : MonoBehaviour
{
	public float timeLeft = 60f;
	public Text countdown;
	public GameObject timerObj;
	public bool TimerTrigger;

	public Text tQTE1, tQTE2, tQTE3, tQTE4, tQTE5, tQTE6;


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

			QTE();
		}
	}

	public void QTE(){
		
	}

}