﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftScript : MonoBehaviour
{
	public GameObject startLoc;
	public GameObject finishLoc;
	public GameObject player;
	public MovementScript movScript;
	public TerminalController server;
	public GameObject interactUI;
    public float speed = 1.0F;
	protected bool atTop;
	protected bool movingUp;
	protected bool movingDown;
    protected float startTime;
    protected float journeyLength;
	// Use this for initialization
	void Start ()
	{
		atTop = false;
		movingUp = false;
		movingDown = false;

		player = GameObject.FindGameObjectWithTag("Player");
		movScript = player.GetComponent<MovementScript>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (movingUp)
		{
			float distCovered = (Time.time - startTime) * speed;
       		float fracJourney = distCovered / journeyLength;

			transform.position = Vector3.Lerp(transform.position, finishLoc.transform.position, Time.deltaTime);
			player.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);

			if (fracJourney >= 1)
			{
				atTop = true;
				movingUp = false;

				movScript.enabled = true;
			}
		}
		else if (movingDown)
		{
			float distCovered = (Time.time - startTime) * speed;
       		float fracJourney = distCovered / journeyLength;

			transform.position = Vector3.Lerp(transform.position, startLoc.transform.position, Time.deltaTime);

			if (fracJourney >= 1)
			{
				atTop = false;
				movingDown = false;

				movScript.enabled = true;
			}
		}
	}
	void OnTriggerEnter(Collider other) 
	{
		if (server.success == true && other.tag == "Player")
		{
			interactUI.SetActive(true);
		}
	}
    void OnTriggerStay(Collider other) 
	{
        if (other.gameObject.tag == "Player" && server.success == true)
		{ 
        	if (Input.GetButtonDown("Interact") == true)
        	{
        		//movScript.enabled = false;
				if (atTop == false)
           		{
                	startTime = Time.time;
                	journeyLength = Vector3.Distance(transform.position, finishLoc.transform.position);

             		movingUp = true;
               		movingDown = false;
            	}
            	else if (atTop == true)
            	{
                	startTime = Time.time;
                	journeyLength = Vector3.Distance(transform.position, startLoc.transform.position);

                	movingUp = false;
                	movingDown = true;
           	 	}	
        	}
        }
    }
	void OnTriggerExit(Collider other) 
	{
		if (server.success == true && other.tag == "Player")
		{
			interactUI.SetActive(false);
		}
	}
}
