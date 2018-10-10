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
	public bool isZeroGravityMovement;
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
	}
	
	// Update is called once per frame
	void Update ()
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
		Debug.Log(_rb.velocity.y);
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
}
