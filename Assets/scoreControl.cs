using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreControl : MonoBehaviour {

    public float score = 0;
    public int strike = 0;
    public int defused = 0;
    public int phase = 0;
    public bool gameover = false;

    // Use this for initialization
    void Start () {
        strike = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (strike >=3 && !gameover)
        {
            Debug.Log("GAME OVER - DEFUSED: " + defused + " | SCORE: "+ score);
            gameover = true;
            Time.timeScale = 0;
        }
	}
}
