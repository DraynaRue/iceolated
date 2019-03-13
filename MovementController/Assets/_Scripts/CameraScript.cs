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

    // Use this for initialization
    void Start()
    {
        // get a reference to Camera
        cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // calculate the movement of the camera
        lookX += speedX * Input.GetAxis("Mouse X");
        lookY -= speedY * Input.GetAxis("Mouse Y");

        lookY = Mathf.Clamp(lookY, -90, 90);

        // rotate the camera	
        Quaternion xQuaternion = Quaternion.AngleAxis (lookX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis (lookY, Vector3.right);
           
        cam.transform.rotation = xQuaternion * yQuaternion;
    }
}
