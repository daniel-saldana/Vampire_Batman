﻿using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour {
    public GameObject[] weaponPlacements = null;
    public GameObject weaponPrefab = null;

	public float crossFireRate = 2.5f;
    public bool canShoot = true;
    public float crossCooldownTimer = 0.0f;

	EnemySight eS;

    public AudioSource cross;

    // Use this for initialization
    void Start()
    {
        cross = FindObjectOfType<AudioSource>();
		eS = GetComponent<EnemySight> ();
    }

    // Update is called once per frame
    void Update()
    {
		crossCooldownTimer += Time.deltaTime;
        if (eS.seePlayer == true)
        {
            if (canShoot == true)
            {
                //source.clip = cross;
                cross.Play();
                //Instantiate(weaponPrefab, transform.position, transform.rotation);
                for (int i = 0; i < weaponPlacements.Length; i++)
                {
                    Instantiate(weaponPrefab, weaponPlacements[i].transform.position, Quaternion.identity);
                    cross.Stop();
					crossCooldownTimer = 0.0f;
                }
				canShoot = false;
            }
            
            {
                //crossCooldownTimer += Time.deltaTime;
                if (crossCooldownTimer >= crossFireRate)
                {

                    crossCooldownTimer = 0.0f;
                    canShoot = true;
                    cross.Play();
                }
            }
        }
    }
}
