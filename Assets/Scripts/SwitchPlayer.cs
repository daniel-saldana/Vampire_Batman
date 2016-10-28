using UnityEngine;
using System.Collections;

public class SwitchPlayer : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
	public GameObject cam3;

    PlayerState state;
    public float playerS;
	public float batTimer;

	public bool batForm = false;
	public bool mistForm = false;

	public BodyController bodCon;

	// Use this for initialization
	void Start ()
    {
        state = FindObjectOfType<PlayerState>();
		bodCon = FindObjectOfType<BodyController> ();
		//bodCon.batMana.CurrentVal = batTimer;
       // state.currentState = PlayerState.StateOfPlayer.Body;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            mistForm = false;
			if (bodCon.batMana.CurrentVal > 0.1f) 
			{
				if (playerS != 1) 
				{
					playerS = 1;
					batForm = true;
				} 
				else 
				{
					playerS = 0;
					batForm = false;
				}
			}

        }
		if (batForm == true) 
		{
			bodCon.batMana.CurrentVal -= Time.deltaTime;
			if (bodCon.batMana.CurrentVal < 0.1f) 
			{
				playerS = 0;
				batForm = false;
			}
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
            batForm = false;

			if (bodCon.mistMana.CurrentVal > 0.1f) 
			{
				if (playerS != 2) 
				{
					playerS = 2;
					mistForm = true;
				} 
				else 
				{
					playerS = 0;
					mistForm = false;
				}
			}

		}
		if (mistForm == true) 
		{
			bodCon.mistMana.CurrentVal -= Time.deltaTime;
			if (bodCon.mistMana.CurrentVal < 0.1f) 
			{
				playerS = 0;
				mistForm = false;
			}
		}

        state.currentState = (PlayerState.StateOfPlayer)playerS;

	    if(state.currentState == PlayerState.StateOfPlayer.Body)
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam2.transform.position = cam1.transform.position;
            cam2.transform.rotation = cam1.transform.rotation;
        }
        if (state.currentState == PlayerState.StateOfPlayer.Bat)
        {   
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam1.transform.position = cam2.transform.position;
        }

		if(state.currentState == PlayerState.StateOfPlayer.Mist)
		{
			cam1.SetActive(true);
			cam2.SetActive(false);
			cam2.transform.position = cam1.transform.position;
			cam2.transform.rotation = cam1.transform.rotation;
		}
    }
}
