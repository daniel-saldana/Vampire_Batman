using UnityEngine;
using System.Collections;

public class LightDamage : MonoBehaviour
{
    public Transform player;

	public float damage = 5;

    public bool seen;
    BodyController bc;

	SwitchPlayer sp;

	// Use this for initialization
	void Start ()
    {
        bc = FindObjectOfType<BodyController>();
		sp = FindObjectOfType<SwitchPlayer> ();
		damage = 5;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (seen) 
		{
			if (sp.mistForm == false) 
			{
				bc.health.CurrentVal -= damage * Time.deltaTime; 
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
