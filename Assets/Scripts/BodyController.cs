using UnityEngine;
using System.Collections;

public class BodyController : MonoBehaviour 
{
	public float inputDelay = 0.1f;
	public float forwardVel = 12;
	public float defaultVel = 12;
	public float rotateVel = 100;
	public float dashVel = 25;
	public float gravity = -9.8f;
	public float dashlength = 1.0f;

	public bool dashReady = false;
	public bool dashing = false;

	public float dashTimer = 0.0f;

	Quaternion targetRotation;
	Rigidbody rb;
	float forwardInput, turnInput, strafeInput;

	public Quaternion TargetRotation
	{
		get{ return targetRotation; }
	}

	// Use this for initialization
	void Start () 
	{
		targetRotation = transform.rotation;
		if (GetComponent<Rigidbody>())
			rb = GetComponent<Rigidbody>();
		else 
				Debug.LogError("Need Rigidbody");
			
		forwardInput = turnInput = strafeInput = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetInput ();
		Turn ();
	}

	void FixedUpdate()
	{
		Run ();
		Strafe ();
		Dash ();
		Gravity ();
	}

	void GetInput()
	{
		forwardInput = Input.GetAxis("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
		strafeInput = Input.GetAxis ("Strafe");
	}

	void Run()
	{
		if (Mathf.Abs (forwardInput) > inputDelay) 
		{
			rb.velocity = transform.forward * forwardInput * forwardVel;
		} 
		else
		rb.velocity = Vector3.zero;
	}

	void Turn()
	{
		if (Mathf.Abs (turnInput) > inputDelay) 
		{
			targetRotation *= Quaternion.AngleAxis (rotateVel * turnInput * Time.deltaTime, Vector3.up);
		}
		transform.rotation = targetRotation;
	}
		
	void Strafe()
	{
		if (Mathf.Abs (strafeInput) > inputDelay) {
			rb.velocity = transform.right * strafeInput * forwardVel;
		} 
	}

	void Dash()
	{
		if (dashReady == true) 
		{
			if (Input.GetKeyDown (KeyCode.LeftShift) && dashReady == true) 
			{
				dashing = true;
			}
		}
		if (dashing == true) 
		{
			dashTimer += Time.deltaTime;
			forwardVel = dashVel;
		}
		if (dashTimer > dashlength) 
		{
			dashTimer = 0.0f;
			forwardVel = defaultVel;
			dashReady = false;
			dashing = false;
		}
	}

	void Gravity()
	{
		rb.AddForce (0, gravity, 0, ForceMode.Impulse);
	}
}
