﻿using UnityEngine;
using System.Collections;

public class LightPointTo : MonoBehaviour {

    public Transform player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player);
	}
}
