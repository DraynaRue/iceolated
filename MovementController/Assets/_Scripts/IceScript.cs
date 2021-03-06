﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceScript : MonoBehaviour {
	public float currentProgress;
	// Use this for initialization
	void Start () {
		currentProgress = 0.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (currentProgress > 0.0f && Gun.isMeltingIce == false)
		{
			Color oldCol;
			Color newCol;
			Renderer rend;
			rend = GetComponent<Renderer>();
			oldCol = rend.material.color;
			newCol = Color.red;

			rend.material.SetColor("_EmissionColor", Color.Lerp(oldCol, newCol, currentProgress / 0.75f) * Mathf.Lerp(0.8457f, 80.0f, currentProgress / 1.0f));
			currentProgress -= Time.deltaTime;
		}
	}
}
