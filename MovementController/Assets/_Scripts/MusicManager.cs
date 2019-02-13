using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicManager : MonoBehaviour {

	public AudioClip mainTheme;
	public AudioClip menuTheme;

	private string lastScene;
	private string currentScene;

	void awake(){
		lastScene = SceneManager.GetActiveScene().name; 
	
	}

	void Start () {
		//AudioManager.Instance.PlayMusic (menuTheme, 2);
	}
	

	void Update () {

		currentScene =SceneManager.GetActiveScene().name;
		 if(currentScene != lastScene) {
            lastScene = currentScene;
            ChangeSong();

		//if (Input.GetKeyDown (KeyCode.Space)) {
		//	AudioManager.Instance.PlayMusic (mainTheme, 2);

		}
	}

	void ChangeSong(){
		if(lastScene == "MainMenu"){
			AudioManager.Instance.PlayMusic (menuTheme, 0.5f);
		}
		else if(lastScene == "Master"){
			AudioManager.Instance.PlayMusic (mainTheme, 2);
		}
	}
	
}
