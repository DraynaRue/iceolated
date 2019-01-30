using System.Collections;
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
	public float rollVal;
	public bool isZeroGravity;
	// get a reference to the camera
	public Camera cam;
	public GameObject camPosN;
	// reference to the player's rigidbody component
	protected Rigidbody _rb;
	protected bool isJumping;
	protected float hor;
	protected float ver;
	public AudioClip a_jetpack;
	public AudioSource AS;

	// Use this for initialization
	void Start ()
	{
		_rb = GetComponent<Rigidbody>();
		isJumping = false;
		//isZeroGravity = true;
/*
		We really don't need this to be set to true everytime we hit play
		it makes testing stuff really annoying ~ DraynaRue [Lead Programmer]
		isZeroGravity = true;
*/
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
			//Debug.Log("We hit the ground!");
			isJumping = false;
		}
	}

	private void NormalMovement() 
	{
		// rotate the player
		_rb.transform.eulerAngles = new Vector3(0, cam.transform.eulerAngles.y, 0);

		CapsuleCollider col = GetComponent<CapsuleCollider>();
		col.height = 1; 
		cam.transform.position = Vector3.Lerp(cam.transform.position, camPosN.transform.position, 1f);

		// calculate player movement
		hor = moveSpeed * Input.GetAxis("Horizontal");
		ver = moveSpeed * Input.GetAxis("Vertical");

		if (Input.GetKey(KeyCode.C))
		{
			ver *= 2.00f;
		}

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
	//	_rb.transform.eulerAngles = new Vector3(0, cam.transform.eulerAngles.y, 0);

		_rb.transform.rotation = cam.transform.rotation;

		//Make the collider a ball and move cam to center
		CapsuleCollider col = GetComponent<CapsuleCollider>();
		col.height = 1;
		cam.transform.position = Vector3.Lerp(cam.transform.position, this.transform.position, 1f);

		// roll the player right
		//rollVal = Input.GetAxis("Roll");
		//if (Input.GetAxis("Roll") != 0)
		//{
		//	Debug.Log("Rotating");
		//}

		// moving forwards
		if (Input.GetAxis("Vertical") > 0 && GetComponent<Fuel>().fuelPercentage > 1)
		{
			Vector3 force = new Vector3(0, 0, jetpackForce) + _rb.transform.forward;
			_rb.AddForce(force, ForceMode.Acceleration);
		}

		// moving backwards
		if (Input.GetAxis("Vertical") < 0 && GetComponent<Fuel>().fuelPercentage > 1)
		{
			Vector3 force = new Vector3(0, 0, jetpackForce) + _rb.transform.forward;
			_rb.AddForce(-force, ForceMode.Acceleration);
		}

		// moving right
		if (Input.GetAxis("Horizontal") > 0 && GetComponent<Fuel>().fuelPercentage > 1)
		{
			Vector3 force = new Vector3(jetpackForce, 0, 0) + _rb.transform.right;
			_rb.AddForce(force, ForceMode.Acceleration);
		}

		// moving left
		if (Input.GetAxis("Horizontal") < 0 && GetComponent<Fuel>().fuelPercentage > 1)
		{
			Vector3 force = new Vector3(jetpackForce, 0, 0) + _rb.transform.right;
			_rb.AddForce(-force, ForceMode.Acceleration);
		}

		// moving up
		if (Input.GetAxis("Jump") > 0 && GetComponent<Fuel>().fuelPercentage > 1)
		{
			Vector3 force = new Vector3(0, jetpackForce, 0) + _rb.transform.up;
			_rb.AddForce(force, ForceMode.Acceleration);
		}

		// moving down
		if (Input.GetAxis("Crouch") > 0 && GetComponent<Fuel>().fuelPercentage > 1)
		{
			Vector3 force = new Vector3(0, jetpackForce, 0) + _rb.transform.up;
			_rb.AddForce(-force, ForceMode.Acceleration);
		}
	}
}
