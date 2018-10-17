using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	// speed at which the camera moves in the x axis
	public float speedX;
	// speed at which the camera moves in the y axis
	public float speedY;
	protected Camera cam;
	protected float lookX;
	protected float lookY;

	// Use this for initialization
	void Start () 
	{	
		//Confining the cursor to the game window and locking it in place
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.lockState = CursorLockMode.Locked;

		// get a reference to Camera
		cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// calculate the movement of the camera
		lookX += speedX * Input.GetAxis("Mouse X");
		lookY -= speedY * Input.GetAxis("Mouse Y");

		// rotate the camera
		cam.transform.eulerAngles = new Vector3(lookY, lookX, 0);
	}
}
