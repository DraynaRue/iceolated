using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMShipMovementScript : MonoBehaviour 
{
	public float MoveSpeed = 0.5f;
	protected GameObject Ship;
	protected GameObject[] waypointArray;
	public int nextWaypointIndex;
	// Use this for initialization
	void Start () 
	{
		Ship = GameObject.Find("Ship_Pod_low");
		waypointArray = GameObject.FindGameObjectsWithTag("Ship-Waypoint");
		nextWaypointIndex = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Ship != null)
		{
			MoveShip();
			if (waypointArray[nextWaypointIndex].GetComponent<MMShipWaypoint>().hasShipReached == true)
			{
				waypointArray[nextWaypointIndex].GetComponent<MMShipWaypoint>().hasShipReached = false;
				
				nextWaypointIndex++;
				if (nextWaypointIndex >= waypointArray.Length)
				{
					nextWaypointIndex = 0;
				}
			}
		}
	}

	void MoveShip () 
	{
		Ship.transform.LookAt(waypointArray[nextWaypointIndex].transform, Vector3.up);
		Ship.transform.position += Ship.transform.forward * MoveSpeed;
	}
}
