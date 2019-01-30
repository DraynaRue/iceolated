using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDAnimScript : MonoBehaviour {
	public float ExpireInterval = 5.00f;
	public GameObject Img1;
	public GameObject Img2;
	protected float timeLeft;
	protected bool isImg1;
	// Use this for initialization
	void Start () {
		timeLeft = ExpireInterval;
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft-= 1 * Time.deltaTime;
		if (timeLeft <= 0)
		{

		}
	}
}
