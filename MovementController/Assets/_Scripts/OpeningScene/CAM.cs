using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAM : MonoBehaviour {

	public GameObject pod;
	public GameObject pos1, pos2, pos3;
	public GameObject canvas;
	public GameObject screenText;
	public bool point2 = false;
	public bool point3 = false;
	public DialougeIntro dialogueIntro;
	
	private bool done = false;

	float t, t2;
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

		if(!done){
			transform.position = Vector3.Lerp(pos1.transform.position, pos2.transform.position, t);
		}
		

		if(transform.position == pos2.transform.position && point2 == false){
			point2 = true;
			screenText.SetActive(true);
			dialogueIntro.GO();
		}

		if(done){
			t2 += Time.deltaTime / timetoreach;
			transform.position = Vector3.Lerp(pos2.transform.position, pos3.transform.position, t2);
		}

		if(Input.GetKeyDown(KeyCode.Return) && done == true){
			cam.depth = -1f;
			canvas.SetActive(true);
			Destroy(this.gameObject);
		}
	}

	public void EndOfCutScene(){
		done = true;
		timetoreach = 4f;
	}
}
