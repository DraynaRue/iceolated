using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAM : MonoBehaviour {

	public GameObject pod;
	public GameObject pos1, pos2;
	public GameObject canvas;
	public GameObject screenText;
	public bool point2 = false;
	public DialougeIntro dialogueIntro;

	float t;
	float timetoreach = 6f;

	private Camera cam;
	
	void Start(){
		cam = gameObject.GetComponent<Camera>();
		canvas.SetActive(false);
		dialogueIntro = this.GetComponent<DialougeIntro>();
	}
	
	void Update () {
		t += Time.deltaTime / timetoreach;
		Vector3 targetDir = pod.transform.position - transform.position;

		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 100f, 100f);
		
		transform.rotation = Quaternion.LookRotation(newDir);

		transform.position = Vector3.Lerp(pos1.transform.position, pos2.transform.position, t);

		if(transform.position == pos2.transform.position && point2 == false){
			point2 = true;
			screenText.SetActive(true);
			dialogueIntro.GO();
		}

		if(Input.GetKeyDown(KeyCode.Return)){
			cam.depth = -1f;
			canvas.SetActive(true);
		}
	}
}
