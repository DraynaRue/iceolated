using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
	public GameObject InteractUI;
	public Image ServerInvIcon;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	void OnTriggerEnter(Collider other) 
	{
		if (InteractUI != null)
		{
			InteractUI.SetActive(true);
		}
	}
	void OnTriggerStay(Collider other)
	{
		if (Input.GetAxis("Interact") > 0)
		{
			if (ServerInvIcon != null)
			{
				if (ServerInvIcon.gameObject.activeSelf == true)
				{
					Debug.Log("Congratulations you have completed the game! Thanks for playing!");
					if (InteractUI != null)
					{
						InteractUI.SetActive(false);
					}
				}
			}
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (InteractUI != null)
		{
			InteractUI.SetActive(false);
		}
	}
}
