using UnityEngine;
using System.Collections;

public class TiltController : MonoBehaviour 
{
	public float inputDelay = 0.1f;
	public float rotateVel = 100;

	Quaternion targetRotation;
	Rigidbody rb;
	float tiltInput;

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

		tiltInput = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetInput ();
		Look ();
	}

	void GetInput()
	{
		tiltInput = Input.GetAxis ("Look");
	}

	void Look()
	{
		if (Mathf.Abs (tiltInput) > inputDelay) 
		{
			targetRotation *= Quaternion.AngleAxis (rotateVel * tiltInput * Time.deltaTime, Vector3.right);
		}
		transform.rotation = targetRotation;
	}
}
