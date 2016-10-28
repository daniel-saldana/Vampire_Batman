using UnityEngine;
using System.Collections;

public class BatSunDamage : MonoBehaviour
{

    public GameObject batSunDamage;

    LightDamage ld;
    PlayerState ps;

    // Use this for initialization
    void Start()
    {
        ps = FindObjectOfType<PlayerState>();
        ld = FindObjectOfType<LightDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ld.seen)
        {

            if (ps.currentState == PlayerState.StateOfPlayer.Bat)
            {
                batSunDamage.SetActive(true);
            }

        }
        else
        {
            batSunDamage.SetActive(false);
        }
    }
}
