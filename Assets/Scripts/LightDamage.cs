using UnityEngine;
using System.Collections;

public class LightDamage : MonoBehaviour
{
    public Transform player;

    public bool seen;
    BodyController bc;

    PlayerState ps;
	// Use this for initialization
	void Start ()
    {
        ps = FindObjectOfType<PlayerState>();
        bc = FindObjectOfType<BodyController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(seen)
        {
            if(ps.currentState != PlayerState.StateOfPlayer.Mist)
            {
                bc.health.CurrentVal -= Time.deltaTime;
            }
        }

        Vector3 fromPosition = transform.position;
        Vector3 toPosition = player.transform.position;
        Vector3 direction = toPosition - fromPosition;


        RaycastHit hit;
        Ray inSight = new Ray(transform.position, direction);
        Debug.DrawRay(transform.position, direction * 200, Color.red);
        if(Physics.Raycast(inSight, out hit, 1000))
        {
            if(hit.collider.tag == "Player")
            {
                seen = true;
            }
            else if(hit.collider.tag != "Player")
            {
                seen = false;
            }
        }
    }
}
