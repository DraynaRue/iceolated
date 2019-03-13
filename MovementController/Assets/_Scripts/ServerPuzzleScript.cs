using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerPuzzleScript : MonoBehaviour
{
	public GameObject InteractUI;
	public Image ServerInvIcon;
	public Camera cam;
	public int ServerIndex;
	public GameObject[] ServerArray;
	// Use this for initialization
	void Start ()
	{
		ServerArray = GameObject.FindGameObjectsWithTag("Server");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	private void OnTriggerStay(Collider other)
	{
		RaycastHit hit;
		Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
		if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
		{
			if (hit.transform.tag == "Server")
			{
				InteractUI.SetActive(true);
				if (Input.GetAxis("Interact") > 0)
				{
					if (hit.transform.gameObject == ServerArray[ServerIndex].gameObject)
					{
						Debug.Log("Found Right Server");
						if (ServerInvIcon != null)
						{
							ServerInvIcon.gameObject.SetActive(true);
						}
					}
					Destroy(hit.transform.gameObject);
				}
			}
			else
			{
				InteractUI.SetActive(false);
			}
		}
	}
}
