using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour
{
    public bool seePlayer = false;
    public GameObject player = null;

    public float turnSpeed = 1f;
    public float maxTurn = 45f;

    public float lineOfSight = 3.5f;
    public float maxSight = 8;

    public float enemyHealth = 5;

    public int moveSpeed;

    public AudioSource bells;

    private Transform myTransform;

	public Transform playerBody;

	public bool inRange = false;

	public bool takingDamage = false;

	public float dist;


    void Awake ()
    {
        myTransform = transform;
    }

	// Use this for initialization
	void Start ()
    {
        bells = FindObjectOfType<AudioSource>();
		//float dist = Vector3.Distance(playerBody.position, transform.position);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//float dist = Vector3.Distance(playerBody.position, transform.position);
		DrainBlood ();
		if (enemyHealth < 0.1f) 
		{
			inRange = false;
			takingDamage = false;
			Destroy (gameObject);
		}

		if (!seePlayer) {
			transform.Rotate (0, turnSpeed, 0);

			if ((transform.rotation.eulerAngles.y > maxTurn && transform.rotation.eulerAngles.y < 180) ||
			             (transform.rotation.eulerAngles.y < 360 - maxTurn && transform.rotation.eulerAngles.y > 180)) {
				turnSpeed *= -1;
			}
		} else
			transform.LookAt (player.transform);

		Vector3 sight = player.transform.position - transform.position;
		float dot = Vector3.Dot (sight, transform.right);

		if (dot < lineOfSight && dot > -lineOfSight) {
			RaycastHit hit;

			if (Physics.Raycast (transform.position, (player.transform.position - transform.position).normalized, out hit, maxSight)) {
				if (hit.collider.name.StartsWith ("Player"))
					seePlayer = true;
				Debug.Log ("IsEEYou");
				bells.Play ();
				{
					//else
					//seePlayer = true;
					bells.Stop ();
					myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
				}
               
			} else
				seePlayer = false;
            
		}
	}
		void DrainBlood()
	{
		float dist = Vector3.Distance (playerBody.position, transform.position);
		if (dist < 2.5) {
			inRange = true;
			print ("Distance to other: " + dist);
		} else if (dist > 2.5) {
			inRange = false;
		}
		if (takingDamage == true) {
			moveSpeed = 0;
			transform.position = transform.position;
			this.enemyHealth -= Time.deltaTime;
		} else if (inRange == false) {
			takingDamage = false;
		}
	}
}