using UnityEngine;
using System.Collections;

public class SwitchPlayer : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    PlayerState state;
   public float playerS;

	// Use this for initialization
	void Start ()
    {
        state = FindObjectOfType<PlayerState>();
       // state.currentState = PlayerState.StateOfPlayer.Body;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (playerS < 1)
            {
                playerS++;
            }
            else
            {
                playerS = 0;
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
    }
}
