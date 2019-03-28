using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEP2 : MonoBehaviour {

	public GameObject interactUI;
	public GameObject qteNumObj;
	public GameObject qteKeyObj;
	public MovementScript player;
	public Text QTEKey;
	public Text QTENum;
	public TimerScript timerTriggerObj;

	public Mission3 mission3;

	public GameObject quest2;

	private bool started = false;

	private float QTE12 = 2f, QTE22 = 1.75f, QTE32 = 1.5f, QTE42 = 1.25f, QTE52 = 1f, QTE62 = 0.75f, QTE72 = 0.5f;
	private bool done02, done12, done22, done32, done42, done52, done62, done72;

	void Restart(){
		Debug.Log("Ok Restarted");
		QTE12 = 2f; QTE22 = 1.75f; QTE32 = 1.5f; QTE42 = 1.25f; QTE52 = 1f; QTE62 = 0.75f; QTE72 = 0.5f;
		done02 = false;
		done12 = false;
		done22 = false;
		done32 = false;
		done42 = false;
		done52 = false;
		done62 = false;
		done72 = false;
	}

	void Start(){
		done02 = true;
		started = false;
		mission3 = (Mission3)FindObjectOfType<Mission3>();
	}

	void Update () {

		if(done02 == false){
			E12();
			QTE12 -= 0.9f * Time.deltaTime;
			Debug.Log("in update");
		}

		if(done12 == true){
			E22();
			QTE22 -= 0.9f * Time.deltaTime;
		}

		if(done22 == true){
			done12 = false;
			E32();
			QTE32 -= 0.9f * Time.deltaTime;
		}

		if(done32 == true){
			done22 = false;
			E42();
			QTE42 -= 0.9f * Time.deltaTime;
		}

		if(done42 == true){
			done32 = false;
			E52();
			QTE52 -= 0.9f * Time.deltaTime;
		}

		if(done52 == true){
			done42 = false;
			E62();
			QTE62 -= 0.9f * Time.deltaTime;
		}

		if(done62 == true){
			done52 = false;
			E72();
			QTE72 -= 0.9f * Time.deltaTime;
		}

		if(done72 == true){
			player.enabled = true;
			qteNumObj.SetActive(false);
			qteKeyObj.SetActive(false);
			TimerScript.TimerTrigger = false;
			//Start Mission 3
			mission3.Mission3Start();
            AudioManager.Instance.PlaySound("Engine_Off", transform.position);
		}
	}

	void E12(){
		Debug.Log("in E12");
		player.enabled = false;
		qteNumObj.SetActive(true);
		qteKeyObj.SetActive(true);

		QTENum.text = QTE12.ToString();
		QTEKey.text = "[X]";
		
		if(Input.GetKeyDown(KeyCode.X) && QTE12 > 0f){ //Win
			done12 = true;
			done02 = false;
		} 
		
		if(QTE12 <= 0f){ //Fail
			QTEKey.text = "Fail, try again... Press 'F'";
			if(Input.GetKeyDown(KeyCode.F)){
				Restart();
			}
		}	
	}

	void E22(){
		QTENum.text = QTE22.ToString();
		QTEKey.text = "[H]";

		if(Input.GetKeyDown(KeyCode.H) && QTE22 > 0f){
			done22 = true;
			done12 = false;
		}

		if(QTE22 <= 0f){
			QTEKey.text = "Fail, try again... Press 'E'";
			if(Input.GetKeyDown(KeyCode.E)){
				Restart();
			}
		}
	}

	void E32(){
		QTENum.text = QTE32.ToString();
		QTEKey.text = "[N]";

		if(Input.GetKeyDown(KeyCode.N) && QTE32 > 0f){
			done32 = true;
			done22 = false;
		}

		if(QTE32 <= 0f){
			QTEKey.text = "Fail, try again... Press 'E'";
			if(Input.GetKeyDown(KeyCode.E)){
				Restart();
			}
		}
	}

	void E42(){
		QTENum.text = QTE42.ToString();
			QTEKey.text = "[Y]";

			if(Input.GetKeyDown(KeyCode.Y) && QTE42 > 0f){
				done42 = true;
				done32 = false;
			}

			if(QTE42 <= 0f){
				QTEKey.text = "Fail, try again... Press 'E'";
				if(Input.GetKeyDown(KeyCode.E)){
					Restart();
				}
			}
	}

	void E52(){

		QTENum.text = QTE52.ToString();
		QTEKey.text = "[B]";

		if(Input.GetKeyDown(KeyCode.B) && QTE52 > 0f){
			done52 = true;
			done42 = false;
		}

		if(QTE52 <= 0f){
			QTEKey.text = "Fail, try again... Press 'E'";
			if(Input.GetKeyDown(KeyCode.E)){
				Restart();
			}
		}
	}

	void E62(){
		QTENum.text = QTE62.ToString();
		QTEKey.text = "[Q]";

		if(Input.GetKeyDown(KeyCode.Q) && QTE62 > 0f){
			done62 = true;
			done52 = false;
		}

		if(QTE62 <= 0f){
			QTEKey.text = "Fail, try again... Press 'E'";
			if(Input.GetKeyDown(KeyCode.E)){
				Restart();
			}
		}
	}

	void E72(){
		QTENum.text = QTE72.ToString();
		QTEKey.text = "[I]";

		if(Input.GetKeyDown(KeyCode.I) && QTE72 > 0f){
			done72 = true;
			done62 = false;
		}

		if(QTE72 <= 0f){
			QTEKey.text = "Fail, try again... Press 'E'";
			if(Input.GetKeyDown(KeyCode.E)){
				Restart();
			}
		}
		
	}

	public void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "Player"){

			if(Input.GetKeyDown(KeyCode.F)){
					Debug.Log("Ok Pressed");
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
