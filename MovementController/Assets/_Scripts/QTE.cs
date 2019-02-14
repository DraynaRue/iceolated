using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE : MonoBehaviour {

	public GameObject interactUI;
	public GameObject qteNumObj;
	public GameObject qteKeyObj;
	public GameObject timerTriggerObj;
	public MovementScript player;
	public bool QTE1Start;
	public Text QTEKey;
	public Text QTENum;

	private float QTE1, QTE2, QTE3, QTE4, QTE5, QTE6, QTE7, QTE8;
	private bool done1, done2, done3, done4, done5, done6, done7, done8;

	void Update () {
		if(QTE1Start == true && done1 == false){
			player.enabled = false;

			QTE1 = (TimerScript.timeLeft / 100f);
			QTENum.text = QTE1.ToString();
			QTEKey.text = "Up";
			qteNumObj.SetActive(true);
			qteKeyObj.SetActive(true);
			if(Input.GetAxis("Vertical") > 0 && QTE1 > 0f){
				done1 = true;
			}
		}

		if(done1 == true && done2 == false){
			QTE2 = (TimerScript.timeLeft / 120f);
			QTENum.text = QTE2.ToString();
			QTEKey.text = "Down";
			if(Input.GetAxis("Vertical") < 0 && QTE2 > 0f){
				done2 = true;
			}
		}

		if(done2 == true && done3 == false){
			QTE3 = (TimerScript.timeLeft / 140f);
			QTENum.text = QTE3.ToString();
			QTEKey.text = "Right";
			if(Input.GetAxis("Horizontal") > 0 && QTE3 > 0f){
				done3 = true;
			}
		}

		if(done3 == true && done4 == false){
			QTE4 = (TimerScript.timeLeft / 160f);
			QTENum.text = QTE4.ToString();
			QTEKey.text = "Down";
			if(Input.GetAxis("Vertical") < 0 && QTE4 > 0f){
				done4 = true;
			}
		}

		if(done4 == true && done5 == false){
			QTE5 = (TimerScript.timeLeft / 180f);
			QTENum.text = QTE5.ToString();
			QTEKey.text = "Left";
			if(Input.GetAxis("Horizontal") < 0 && QTE5 > 0f){
				done5 = true;
			}
		}

		if(done5 == true && done6 == false){
			QTE6 = (TimerScript.timeLeft / 200f);
			QTENum.text = QTE6.ToString();
			QTEKey.text = "Down";
			if(Input.GetAxis("Vertical") < 0 && QTE6 > 0f){
				done6 = true;
			}
		}

		if(done6 == true && done7 == false){
			QTE7 = (TimerScript.timeLeft / 220f);
			QTENum.text = QTE7.ToString();
			QTEKey.text = "Left";
			if(Input.GetAxis("Horizontal") < 0 && QTE7 > 0f){
				done7 = true;
			}
		}

		if(done7 == true && done8 == false){
			QTE8 = (TimerScript.timeLeft / 240f);
			QTENum.text = QTE8.ToString();
			QTEKey.text = "Up";
			if(Input.GetAxis("Vertical") > 0 && QTE8 > 0f){
				done8 = true;
			}
		}

		if(done8){
			player.enabled = true;
			Destroy(timerTriggerObj);
			qteNumObj.SetActive(false);
			qteKeyObj.SetActive(false);
			TimerScript.timeLeft = 0f;
		}
	}

	public void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			interactUI.SetActive(true);
			if(Input.GetKeyDown(KeyCode.F))
			{
				QTE1Start = true;
				interactUI.SetActive(false);
			}
		}
	}
}	
