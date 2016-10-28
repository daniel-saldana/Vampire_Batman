using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BodyController : MonoBehaviour 
{
	/*public float inputDelay = 0.1f;

	public float rotateVel = 100;
	public float dashVel = 25;
	//public float jumpForce = 25;

	public float gravity = -9.8f;

	Quaternion targetRotation;
	Rigidbody rb;
	float forwardInput, turnInput, strafeInput;
	*/
	public float dashTimer = 0.0f;

	public float floatSpeed = 0.0f;

	public float dashlength = 1.0f;
	public float dashVel = 25;
	//public float forwardVel = 12;
	//public float defaultVel = 12;
	public bool dashReady = false;
	public bool dashing = false;
	public Stat health;
	public Stat batMana;
	public Stat dashMana;
	public Stat mistMana;

	public SwitchPlayer sp;
	/*public Quaternion TargetRotation
	{
		get{ return targetRotation; }
	}
*/
	// Use this for initialization
	void Start () 
	{
		sp = FindObjectOfType<SwitchPlayer> ();
		floatSpeed = floatSpeed * Time.deltaTime;
		dashVel = dashVel * Time.deltaTime;
		/*
		targetRotation = transform.rotation;
		if (GetComponent<Rigidbody>())
			rb = GetComponent<Rigidbody>();
		else 
				Debug.LogError("Need Rigidbody");
			
		forwardInput = turnInput = strafeInput = 0;
		*/
	}

	public void Awake()
	{
		health.Initialize ();
		batMana.Initialize ();
		dashMana.Initialize ();
		mistMana.Initialize ();
		//deathScreen.SetActive(false);
	}

	// Update is called once per frame

    public void Update()
    {
		Dash ();
		MistControl ();
        if(health.CurrentVal < 0.1f)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
	/*
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
		//Jump ();
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
*/
	void Dash()
	{
		if (dashMana.CurrentVal > 0.5f) 
		{
			dashReady = true;
		}
		if (dashReady == true) 
		{
			if (sp.mistForm == false && sp.batForm == false) 
			{
				if (Input.GetKeyDown (KeyCode.LeftShift) && dashReady == true) 
				{
					dashing = true;
				}
			}
		}
		if (dashing == true) 
		{
			dashTimer += Time.deltaTime;
			dashMana.CurrentVal -= Time.deltaTime;
			if (Input.GetKey(KeyCode.W))
			{
				transform.Translate (Vector3.forward * dashVel);
			}
			if (Input.GetKey (KeyCode.S)) {
				transform.Translate (Vector3.back * dashVel);
			}
			if (Input.GetKey (KeyCode.A)) {
				transform.Translate (Vector3.left * dashVel);
			}
			if (Input.GetKey(KeyCode.D)) 
			{
				transform.Translate (Vector3.right * dashVel);
			}

		}

		if (dashTimer > dashlength) 
		{
			dashTimer = 0.0f;
			//forwardVel = defaultVel;
			dashReady = false;
			dashing = false;
		}
		if (dashMana.CurrentVal <= 0.1f) 
		{
			dashReady = false;
		}
	}

	void MistControl()
	{
		if (sp.mistForm == true) 
		{
			if (Input.GetKey (KeyCode.Space)) 
			{
				transform.Translate (Vector3.up * floatSpeed);
			}
		}
	}
		/*
	void Gravity()
	{
		rb.AddForce (0, gravity, 0, ForceMode.Impulse);
	}*/
}
