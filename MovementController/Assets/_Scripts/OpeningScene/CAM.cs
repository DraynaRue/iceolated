using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAM : MonoBehaviour {

	public GameObject pod;
	public GameObject pos1, pos2;

	float t;
	float timetoreach = 6f;

	private Camera cam;
	
	void Start(){
		cam = gameObject.GetComponent<Camera>();
	}
	void Update () {
		t += Time.deltaTime / timetoreach;
		Vector3 targetDir = pod.transform.position - transform.position;

		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 100f, 100f);
		
		transform.rotation = Quaternion.LookRotation(newDir);

		transform.position = Vector3.Lerp(pos1.transform.position, pos2.transform.position, t);

		if(transform.position == pos2.transform.position){
			StartCoroutine(CAMMOVE());
		}
	}

	IEnumerator CAMMOVE(){
		yield return new WaitForSeconds(4f);
		cam.depth = -1f;
	}
}
