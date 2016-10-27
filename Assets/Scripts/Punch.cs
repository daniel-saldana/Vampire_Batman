using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour {

    public Animator anim;

	public PlayerState ps;

	public BodyController bc;

	//public BoxCollider bc;
	//public MeshRenderer mr;

    // Use this for initialization
    void Start () 
	{
        anim = GetComponent<Animator>();
        ps = FindObjectOfType<PlayerState>();

		//bc.enabled = false;
		//mr.enabled = false;
    }
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Fire1") && ps.currentState == PlayerState.StateOfPlayer.Body)
        {
            anim.SetTrigger("HandChop");
        }

    }
}
