﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
	// speed at which the player moves
	public float moveSpeed;
	// force at which the player jumps
	public float jumpForce;
	// force provided by the jetpack in zero gravity movement
	public float jetpackForce;
	// used to enable/disable the player's zero gravity movement
	public bool isZeroGravity;
	// get a reference to the camera
	public Camera cam;
	// get a reference to the fuel gauge
	public GameObject fuelGauge;
	// reference to the player's rigidbody component
	protected Rigidbody _rb;
	protected bool isJumping;
	protected float hor;
	protected float ver;

	// Use this for initialization
	void Start ()
	{
		_rb = GetComponent<Rigidbody>();
		isJumping = false;
		isZeroGravity = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isZeroGravity == false)
		{
			_rb.useGravity = true;
			NormalMovement();
		}
		else if (isZeroGravity == true)
		{
			_rb.useGravity = false;
			ZeroGravityMovement();
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		// check if player is on the ground
		if (other.collider.tag == "Ground" && _rb.velocity.y < 1 /*|| other.collider.tag == "Ground" && _rb.velocity.y > -1*/)
		{
			Debug.Log("We hit the ground!");
			isJumping = false;
		}
	}

	private void NormalMovement() 
	{
		// rotate the player
		_rb.transform.eulerAngles = new Vector3(0,cam.transform.eulerAngles.y,0);

		// calculate player movement
		hor = moveSpeed * Input.GetAxis("Horizontal");
		ver = moveSpeed * Input.GetAxis("Vertical");

		// move the player
		_rb.transform.position += _rb.transform.forward * ver;
		_rb.transform.position += _rb.transform.right * hor;

		// jumping
		if (Input.GetAxis("Jump") > 0 && isJumping == false)
		{
			_rb.velocity = new Vector2(0, jumpForce);
			isJumping = true;
		}
		//Debug.Log(_rb.velocity.y);
	}

	private void ZeroGravityMovement()
	{
		// yaw the player
		_rb.transform.eulerAngles = new Vector3(0, cam.transform.eulerAngles.y, 0);

		// checking to see if player has fuel to move in zero gravity
		if (fuelGauge.GetComponent<Fuel>().isOutOfFuel != true)
		{
			// moving forwards
			if (Input.GetAxis("Vertical") > 0)
			{
				Vector3 force = new Vector3(0, 0, jetpackForce) + _rb.transform.forward;
				_rb.AddForce(force, ForceMode.Acceleration);
			}
			// moving backwards
			if (Input.GetAxis("Vertical") < 0)
			{
				Vector3 force = new Vector3(0, 0, jetpackForce) + _rb.transform.forward;
				_rb.AddForce(-force, ForceMode.Acceleration);
			}

			// moving right
			if (Input.GetAxis("Horizontal") > 0)
			{
				Vector3 force = new Vector3(jetpackForce, 0, 0) + _rb.transform.right;
				_rb.AddForce(force, ForceMode.Acceleration);
			}

			// moving left
			if (Input.GetAxis("Horizontal") < 0)
			{
				Vector3 force = new Vector3(jetpackForce, 0, 0) + _rb.transform.right;
				_rb.AddForce(-force, ForceMode.Acceleration);
			}

			// moving up
			if (Input.GetAxis("Jump") > 0)
			{
				Vector3 force = new Vector3(0, jetpackForce, 0) + _rb.transform.up;
				_rb.AddForce(force, ForceMode.Acceleration);
			}

			// moving down
			if (Input.GetAxis("Crouch") > 0)
			{
				Vector3 force = new Vector3(0, jetpackForce, 0) + _rb.transform.up;
				_rb.AddForce(-force, ForceMode.Acceleration);
			}
		}
	}
}
