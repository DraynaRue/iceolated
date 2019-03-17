using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelMap : MonoBehaviour {

	public GameObject map;
	public bool mapObtained = false;
	public bool mapOpen = false;

	public GameObject journal;
	public bool journalOpen = false;
	public Text journalText;
	public QuestObjective qO;

	public GameObject cb, er1, tp1, lq1, lq2, st, er2, c, rr, tp2, gr, aic, cock, conf, capt;
	public GameObject YAH;

	void Start(){
		qO = (QuestObjective)FindObjectOfType<QuestObjective>();
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.M) && mapObtained == true && mapOpen == false){
			mapOpen = true;
			map.SetActive(true);
		} else if (mapOpen == true && Input.GetKeyDown(KeyCode.M)){
			mapOpen = false;
			map.SetActive(false);
		}

	}

	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "_cb"){
			YAH.transform.position = cb.transform.position;
		}
		if(other.gameObject.tag == "_er1"){
			YAH.transform.position = er1.transform.position;
		}
		if(other.gameObject.tag == "_tp1"){
			YAH.transform.position = tp1.transform.position;
		}
		if(other.gameObject.tag == "_lq1"){
			YAH.transform.position = lq1.transform.position;
		}
		if(other.gameObject.tag == "_lq2"){
			YAH.transform.position = lq2.transform.position;
		}
		if(other.gameObject.tag == "_st"){
			YAH.transform.position = st.transform.position;
		}
		if(other.gameObject.tag == "_er2"){
			YAH.transform.position = er2.transform.position;
		}
		if(other.gameObject.tag == "_c"){
			YAH.transform.position = c.transform.position;
		}
		if(other.gameObject.tag == "_rr"){
			YAH.transform.position = rr.transform.position;
		}
		if(other.gameObject.tag == "_tp2"){
			YAH.transform.position = tp2.transform.position;
		}
		if(other.gameObject.tag == "_gr"){
			YAH.transform.position = gr.transform.position;
		}
		if(other.gameObject.tag == "_aic"){
			YAH.transform.position = aic.transform.position;
		}
		if(other.gameObject.tag == "_lq2"){
			YAH.transform.position = lq2.transform.position;
		}
		if(other.gameObject.tag == "_cock"){
			YAH.transform.position = cock.transform.position;
		}
		if(other.gameObject.tag == "_conf"){
			YAH.transform.position = conf.transform.position;
		}
		if(other.gameObject.tag == "_capt"){
			YAH.transform.position = capt.transform.position;
		}
	}

	public void ObtainMap(){
		mapObtained = true;
	}
}
