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
    public bool isZeroGravity;
    public bool jetpackToggle;
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
    public GameObject zeroGIcon;
    protected float lerpProgress;
    protected bool isBobbingUp;

    // Use this for initialization
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        isJumping = false;
        lerpProgress = 0;
        isBobbingUp = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isZeroGravity == false)
        {
            if (zeroGIcon != null)
            {
                zeroGIcon.SetActive(false);
            }
            _rb.useGravity = true;
            NormalMovement();
        }
        else if (isZeroGravity == true)
        {   
            if (zeroGIcon != null)
            {
                zeroGIcon.SetActive(true);
            }
            _rb.useGravity = false;
            ZeroGravityMovement();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // check if player is on the ground
        if (other.collider.tag == "Ground" && _rb.velocity.y < 1)
        {
            isJumping = false;
        }

    }

    private void NormalMovement()
    {

        // rotate the player
        //_rb.transform.eulerAngles = new Vector3(0, cam.transform.eulerAngles.y, 0);

        CapsuleCollider col = GetComponent<CapsuleCollider>();
        col.height = 1.4f;
        cam.transform.position = Vector3.Lerp(cam.transform.position, camPosN.transform.position, 1f);

        // calculate player movement
        hor = moveSpeed * Input.GetAxis("Horizontal");
        ver = moveSpeed * Input.GetAxis("Vertical");

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            cam.transform.localPosition = new Vector3(0, Mathf.Lerp(0.32f, 0.48f, lerpProgress / 2.0f), 0);
            if (isBobbingUp)
            {
                lerpProgress += 0.1f;
                if (lerpProgress >= 2.0f)
                {
                    isBobbingUp = false;
                }
            }
            else if (!isBobbingUp)
            {
                lerpProgress -= 0.1f;
                if (lerpProgress <= 0)
                {
                    isBobbingUp = true;
                }
            }
           // Debug.Log("Lerp Progress is: " + lerpProgress);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            ver *= 2.00f;
        }

        // move the player
        _rb.transform.position += _rb.transform.forward * ver;
        _rb.transform.position += _rb.transform.right * hor;

        if (Input.GetKeyDown(KeyCode.T))
        {
            jetpackToggle = !jetpackToggle;
        }

        // jumping
        if (Input.GetAxis("Jump") > 0 && isJumping == false && jetpackToggle == false)
        {
            _rb.velocity = new Vector2(0, jumpForce);
            isJumping = true;
        }
        else if (Input.GetAxis("Jump") > 0 && jetpackToggle == true)
        {
            _rb.velocity = new Vector2(0, jetpackForce * 10);
        }
    }

    private void ZeroGravityMovement()
    {
        _rb.transform.rotation = cam.transform.rotation;

        //Make the collider a ball and move cam to center
        CapsuleCollider col = GetComponent<CapsuleCollider>();
        col.height = 0.75f;
        cam.transform.position = Vector3.Lerp(cam.transform.position, this.transform.position, 1f);

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
