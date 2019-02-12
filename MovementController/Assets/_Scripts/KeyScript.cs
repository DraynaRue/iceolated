using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

	public GameObject keyUI;
	public GameObject usernamePassword;
	public bool isIDCard;
	public string username;
	public string password;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Interact ()
	{
		GetComponent<InteractScript>().Player.GetComponent<InventoryScript>().inv.Add(this.gameObject);
		this.gameObject.SetActive(false);
		keyUI.SetActive(true);
		if (isIDCard == true)
		{
			usernamePassword.SetActive(true);
		}
	}
}
