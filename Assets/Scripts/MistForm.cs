using UnityEngine;
using System.Collections;

public class MistForm : MonoBehaviour {


    PlayerState ps;
    Renderer rd;
    public GameObject particals;
    public GameObject sunDamage;

    LightDamage ld;


	// Use this for initialization
	void Start () {
        rd = GetComponent<Renderer>();
        ps = FindObjectOfType<PlayerState>();
        ld = FindObjectOfType<LightDamage>();
	}
	
	// Update is called once per frame
	void Update () {
        if (ld.seen)
        {
            if(ps.currentState == PlayerState.StateOfPlayer.Body)
            {
                sunDamage.SetActive(true);
            }
            else
            {
                sunDamage.SetActive(false);
            }
        }

        if (!ld.seen)
        {
            sunDamage.SetActive(false);
        }

        


	if(ps.currentState == PlayerState.StateOfPlayer.Mist)
        {
            particals.SetActive(true);
            rd.enabled = false;
        }

        else
        {
            particals.SetActive(false);
            rd.enabled = true;
        }
	}
}
