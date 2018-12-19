using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	// speed at which the camera moves in the x axis
	public float speedX;
	// speed at which the camera moves in the y axis
	public float speedY;
	public MovementScript mov;
	protected Camera cam;
	protected float lookX;
	protected float lookY;
	protected float lookZ;

	// Use this for initialization
	void Start () 
	{
		// get a reference to Camera
		cam = GetComponent<Camera>();
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// calculate the movement of the camera
		lookX += speedX * Input.GetAxis("Mouse X");
		lookY -= speedY * Mathf.Clamp(Input.GetAxis("Mouse Y"), -90.0f , 90.0f);
		
		//lookZ += mov.rollVal;
		// rotate the camera	
		cam.transform.rotation = Quaternion.Slerp(mov.transform.rotation, Quaternion.Euler(Mathf.Clamp(lookY, -90.0f, 90.0f), lookX, 0), 0.9f);
	}
}
