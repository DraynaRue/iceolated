using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScene : MonoBehaviour 
{
	public float timeElapsed;
	public GameObject deathSceneHolder;	
	void Start ()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	void Update()
	{
		timeElapsed -= Time.deltaTime;
		if(timeElapsed <= 0)
		{
			deathSceneHolder.SetActive(true);
		}
	}
	public void Retry()
	{
		SceneManager.LoadScene ("MainMenu");
	}
	public void Credits()
	{
		SceneManager.LoadScene ("Luke");
	} 
	
}
