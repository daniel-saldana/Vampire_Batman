using UnityEngine;
using System.Collections;

public class MistMovement : MonoBehaviour 
{
	public float inputDelay = 0.1f;
	public float forwardVel = 12;
	public float rotateVel = 100;
	public float verticalSpeed;

	public float ascendInput;

	public float startingAltitude;
	public float currentAltitude;
	public float maxAltitude;
	public float minAltitude;

	public float gravity = -9.8f;

	float forwardInput, turnInput, strafeInput;
	Quaternion targetRotation;
	Rigidbody rb;

	//public Vector3 pos;

	public float speed;

	public Quaternion TargetRotation
	{
		get{ return targetRotation; }
	}

	// Added speed defaults
	void Start ()
	{
		ascendInput = 0;
		speed = speed * Time.deltaTime;
		verticalSpeed = verticalSpeed * Time.deltaTime;
		forwardInput = turnInput = strafeInput = 0;
		rb = GetComponent<Rigidbody>();
	}

	//Starts the Bat at the default starting altitude
	void OnEnable()
	{
		if(transform.position.y != startingAltitude)
		{
			transform.position = new Vector3(transform.position.x, startingAltitude, transform.position.z);        
		}
	}

	//Gets Input controls for flying
	void Update()
	{
		Ascend ();
		GetInput ();
		Turn ();
	}

	//Changed controls to allow Bat to fly Forward and Backward. Bat flys backward at a slower rate.
	void FixedUpdate()
	{
		Ascend ();
		Run ();
		Strafe ();
		Gravity ();	
	}

	//Controls ascending and descending on the global Y axis. KeyCode."D" for up and KeyCode."A" for down.
	void GetInput()
	{
		ascendInput = Input.GetAxis ("Vertical");
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

	void Ascend()
	{
		if (Mathf.Abs (ascendInput) > inputDelay) 
		{
			transform.Translate(new Vector3(0, verticalSpeed * ascendInput, 0));
		} 

		//Limits the altitude to within a set range

		if (transform.position.y >= maxAltitude) 
		{
			transform.position = new Vector3(transform.position.x, maxAltitude, transform.position.z);   
		}

		if (transform.position.y <= minAltitude) 
		{
			transform.position = new Vector3(transform.position.x, minAltitude, transform.position.z);   		
		}
	}

	void Gravity()
	{
		rb.AddForce (0, gravity, 0, ForceMode.Impulse);
	}
}
