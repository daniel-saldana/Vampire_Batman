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

    public int enemyHealth = 5;

    public int moveSpeed;

    public AudioSource bells;

    private Transform myTransform;
    void Awake ()
    {
        myTransform = transform;
    }

	// Use this for initialization
	void Start ()
    {
        bells = FindObjectOfType<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!seePlayer)
        {
            transform.Rotate(0, turnSpeed, 0);

            if ((transform.rotation.eulerAngles.y > maxTurn && transform.rotation.eulerAngles.y < 180) ||
                (transform.rotation.eulerAngles.y < 360 - maxTurn && transform.rotation.eulerAngles.y > 180))
            {
                turnSpeed *= -1;
            }
        }
        else
            transform.LookAt(player.transform);

        Vector3 sight = player.transform.position - transform.position;
        float dot = Vector3.Dot(sight, transform.right);

        if(dot < lineOfSight && dot > -lineOfSight)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, (player.transform.position - transform.position).normalized, out hit, maxSight))
            {
                if (hit.collider.name == "Player")
                    seePlayer = true;
                bells.Play();
                {
                     //else
                    seePlayer = false;
                    bells.Stop();
                    myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
                }
               
            }
            else
                seePlayer = false;
            
        }
	}
}
