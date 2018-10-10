using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
	// speed at which the player moves
	public float moveSpeed;
	// force at which the player jumps
	public float jumpForce;
	// used to enable/disable the player's zero gravity movement
	public bool isZeroGravity;
	// get a reference to the camera
	public Camera cam;
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
		//isZeroGravity = false;
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
		// rotate the player
		_rb.transform.eulerAngles = new Vector3(0,cam.transform.eulerAngles.y,0);

		// moving forwards
		if (Input.GetAxis("Vertical") > 0)
		{
			Vector3 force = new Vector3(0, 0, moveSpeed) + _rb.transform.forward;
			_rb.AddForce(force, ForceMode.Impulse);
		}
		
		// moving backwards
		if (Input.GetAxis("Vertical") < 0)
		{
			Vector3 force = new Vector3(0, 0, moveSpeed) + _rb.transform.forward;
			_rb.AddForce(-force, ForceMode.Impulse);
		}

		// moving up
		if (Input.GetAxis("Jump") > 0)
		{
			_rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
		}

		// moving down
		if (Input.GetAxis("Crouch") > 0)
		{
			_rb.AddForce(new Vector3(0, -jumpForce, 0), ForceMode.Impulse);
		}
	}
}
