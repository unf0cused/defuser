﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class utilityButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
            Time.timeScale = 1f;
        }

    }
}
