using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour {

	public GameObject pauseMenu;
	MovementScript pController;

	CameraScript cScript;

	// Use this for initialization
	void Start () {
		pController = GameObject.Find ("_Player").GetComponent <MovementScript>();
		cScript = GameObject.Find ("Camera").GetComponent <CameraScript>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.P)) {
			pauseMenu.SetActive (true);
			Time.timeScale = 0f;
			pController.enabled = false;
			cScript.enabled = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		
	}
	public void Resumegame(){
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
		pController.enabled = true;
		Cursor.visible = false;
		cScript.enabled = true;
	}
	public void ReturnMenu(){
		SceneManager.LoadScene("MainMenu");
	}
}
