using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMShipWaypoint : MonoBehaviour 
{
	public bool hasShipReached;
	protected GameObject ship;
	protected MMShipMovementScript shipMovScript;
	// Use this for initialization
	void Start () 
	{
		hasShipReached = false;

		ship = GameObject.Find("Ship_Pod_low");
		shipMovScript = ship.GetComponent<MMShipMovementScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject == ship)
		{
			hasShipReached = true;
		}
	}
}
