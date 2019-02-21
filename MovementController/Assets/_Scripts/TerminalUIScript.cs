using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalUIScript : MonoBehaviour {
	public TerminalController server;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Login()
	{
		if (server.usernameField.text == server.username && server.passwordField.text == server.password)
		{
			server.xScript.usernamePassword.SetActive(false);

			server.usernameField.text = "";
			server.passwordField.text = "";

			server.loginScreen.SetActive(false);
			server.terminalMenu.SetActive(true);
		}
	}
	public void Logout()
	{
		server.terminalMenu.SetActive(false);
		server.loginScreen.SetActive(true);
		server.terminalInterface.SetActive(false);

		server.camScript.enabled = true;
		server.movScript.enabled = true;
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.lockState = CursorLockMode.Locked;
	}
	public void AccessScreen(string ScreenName)
	{
		Image[] ScreenImageArray = server.terminalInterface.GetComponentsInChildren<Image>(false);
		for (int i = 0; i < ScreenImageArray.Length - 1; i++)
		{
			GameObject Screen = ScreenImageArray[i].gameObject;
			if (Screen.gameObject.name == ScreenName)
			{
				Screen.SetActive(true);
			}
		}
		ScreenImageArray[1].gameObject.SetActive(false);
	}
	public void BackToMenu()
	{
		Image[] ScreenImageArray = server.terminalInterface.GetComponentsInChildren<Image>(false);
		GameObject Screen = ScreenImageArray[1].gameObject;
		Debug.Log(Screen.name);
		Screen.SetActive(false);
		server.terminalMenu.SetActive(true);
	}
	public void EnableGravity()
	{
		server.success = true;
	}
}
