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
	public Text QTEKey;
	public Text QTENum;
	
	public GameObject thisGen;
	private bool started = false;

	private float QTE1 = 2f, QTE2 = 1.75f, QTE3 = 1.5f, QTE4 = 1.25f, QTE5 = 1f, QTE6 = 0.75f, QTE7 = 0.5f;
	private bool done0, done1, done2, done3, done4, done5, done6, done7;

	void Restart(){
		QTE1 = 2f; QTE2 = 1.75f; QTE3 = 1.5f; QTE4 = 1.25f; QTE5 = 1f; QTE6 = 0.75f; QTE7 = 0.5f;
		done0 = false;
		done1 = false;
		done2 = false;
		done3 = false;
		done4 = false;
		done5 = false;
		done6 = false;
		done7 = false;
	}

	void Start(){
		done0 = true;
	}

	void Update () {

		if(done0 == false){
			E1();
			QTE1 -= 0.9f * Time.deltaTime;
		}

		if(done1 == true){
			E2();
			QTE2 -= 0.9f * Time.deltaTime;
		}

		if(done2 == true){
			done1 = false;
			E3();
			QTE3 -= 0.9f * Time.deltaTime;
		}

		if(done3 == true){
			done2 = false;
			E4();
			QTE4 -= 0.9f * Time.deltaTime;
		}

		if(done4 == true){
			done3 = false;
			E5();
			QTE5 -= 0.9f * Time.deltaTime;
		}

		if(done5 == true){
			done4 = false;
			E6();
			QTE6 -= 0.9f * Time.deltaTime;
		}

		if(done6 == true){
			done5 = false;
			E7();
			QTE7 -= 0.9f * Time.deltaTime;
		}

		if(done7 == true){
			player.enabled = true;
			qteNumObj.SetActive(false);
			qteKeyObj.SetActive(false);
			AudioManager.Instance.PlaySound("Engine_Off", transform.position);
			Destroy(thisGen);
		}
	}

	void E1(){
		player.enabled = false;
		qteNumObj.SetActive(true);
		qteKeyObj.SetActive(true);

		QTENum.text = QTE1.ToString();
		QTEKey.text = "[D]";
		
		if(Input.GetKeyDown(KeyCode.D) && QTE1 > 0f){ //Win
			done1 = true;
			done0 = true;
		} 
		
		if(QTE1 <= 0f){ //Fail
			QTEKey.text = "Fail, try again... Press 'E'";
			if(Input.GetKeyDown(KeyCode.E)){
				Restart();
			}
		}	
	}

	void E2(){
		QTENum.text = QTE2.ToString();
		QTEKey.text = "[K]";

		if(Input.GetKeyDown(KeyCode.K) && QTE2 > 0f){
			done2 = true;
			done1 = false;
		}

		if(QTE2 <= 0f){
			QTEKey.text = "Fail, try again... Press 'E'";
			if(Input.GetKeyDown(KeyCode.E)){
				Restart();
			}
		}
	}

	void E3(){
		QTENum.text = QTE3.ToString();
		QTEKey.text = "[G]";

		if(Input.GetKeyDown(KeyCode.G) && QTE3 > 0f){
			done3 = true;
			done2 = false;
		}

		if(QTE3 <= 0f){
			QTEKey.text = "Fail, try again... Press 'E'";
			if(Input.GetKeyDown(KeyCode.E)){
				Restart();
			}
		}
	}

	void E4(){
		QTENum.text = QTE4.ToString();
			QTEKey.text = "[L]";

			if(Input.GetKeyDown(KeyCode.L) && QTE4 > 0f){
				done4 = true;
				done3 = false;
			}

			if(QTE4 <= 0f){
				QTEKey.text = "Fail, try again... Press 'E'";
				if(Input.GetKeyDown(KeyCode.E)){
					Restart();
				}
			}
	}

	void E5(){

		QTENum.text = QTE5.ToString();
		QTEKey.text = "[Z]";

		if(Input.GetKeyDown(KeyCode.Z) && QTE5 > 0f){
			done5 = true;
			done4 = false;
		}

		if(QTE5 <= 0f){
			QTEKey.text = "Fail, try again... Press 'E'";
			if(Input.GetKeyDown(KeyCode.E)){
				Restart();
			}
		}
	}

	void E6(){
		QTENum.text = QTE6.ToString();
		QTEKey.text = "[A]";

		if(Input.GetKeyDown(KeyCode.A) && QTE6 > 0f){
			done6 = true;
			done5 = false;
		}

		if(QTE6 <= 0f){
			QTEKey.text = "Fail, try again... Press 'E'";
			if(Input.GetKeyDown(KeyCode.E)){
				Restart();
			}
		}
	}

	void E7(){
		QTENum.text = QTE7.ToString();
		QTEKey.text = "[V]";

		if(Input.GetKeyDown(KeyCode.V) && QTE7 > 0f){
			done7 = true;
			done6 = false;
		}

		if(QTE7 <= 0f){
			QTEKey.text = "Fail, try again... Press 'E'";
			if(Input.GetKeyDown(KeyCode.E)){
				Restart();
			}
		}
		
	}

	public void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Player"){

			if(Input.GetKeyDown(KeyCode.F)){
					interactUI.SetActive(false);
					Restart();
            }
		}
	}

	public void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player" && started == false){
			interactUI.SetActive(true);
			started = true;
		}
	}
	
	public void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player"){
			interactUI.SetActive(false);
		}
	}
}	
