using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalUIScript : MonoBehaviour {
	public TerminalController server;
	public MovementScript movement;
	public liftScript lift;

	// Use this for initialization
	void Start () {
		movement = (MovementScript)FindObjectOfType<MovementScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Login()
	{
		if (server.usernameField.text == server.username && server.passwordField.text == server.password)
		{
			if (server.xScript != null)
			{
				server.xScript.usernamePassword.SetActive(false);
			}

			server.usernameField.text = "";
			server.passwordField.text = "";
			server.loginScreen.SetActive(false);
			server.terminalMenu.SetActive(true);
			AudioManager.Instance.PlaySound("Buttons", transform.position);
		}
	}
	public void Logout()
	{
		server.terminalMenu.SetActive(false);
		server.bypassScreen.SetActive(false);
		server.loginScreen.SetActive(true);
		server.terminalInterface.SetActive(false);
		server.camScript.enabled = true;
		server.movScript.enabled = true;
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.lockState = CursorLockMode.Locked;
		AudioManager.Instance.PlaySound("Buttons", transform.position);
	}
	public void AccessScreen(string ScreenName)
	{
		Image[] ScreenImageArrayOn = server.terminalInterface.GetComponentsInChildren<Image>(true);

		for (int i = 0; i < ScreenImageArrayOn.Length; i++)
		{
			GameObject Screen = ScreenImageArrayOn[i].gameObject;
			Debug.Log("Found: " + ScreenImageArrayOn[i].gameObject.name);
			if (Screen.gameObject.name == ScreenName)
			{
				Debug.Log("Turning On: " + Screen);
				Screen.SetActive(true);
			}
		}
		Image[] ScreenImageArrayOff = server.terminalInterface.GetComponentsInChildren<Image>(false);
		Debug.Log("Turning Off: " + ScreenImageArrayOff[1].gameObject.name);
		ScreenImageArrayOff[1].gameObject.SetActive(false);
	}
	public void BackToMenu()
	{
		Image[] ScreenImageArray = server.terminalInterface.GetComponentsInChildren<Image>(false);
		GameObject Screen = ScreenImageArray[1].gameObject;
		Debug.Log(Screen.name);
		Screen.SetActive(false);
		server.terminalMenu.SetActive(true);
		AudioManager.Instance.PlaySound("Buttons", transform.position);
	}
	public void EnableGravity()
	{
		server.success = true;
		AudioManager.Instance.PlaySound("Buttons", transform.position);
	}

	public void DisableGravityCanteen()
	{
		movement.isZeroGravity = true;
		AudioManager.Instance.PlaySound("Buttons", transform.position);
	}

	public void EnableGravityCanteen()
	{
		movement.isZeroGravity = false;
		AudioManager.Instance.PlaySound("Buttons", transform.position);
	}
}
