using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTokens : MonoBehaviour {

    public GameObject token;
    public GameObject[] gos;

    public int phase = 0;
    public float delay = 1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gos = GameObject.FindGameObjectsWithTag("Token");

        if (gos.Length <= 0)
        {
            phase++;
            delay -= 0.1f;
            spawnToken(phase);
        }
    }

    void spawnToken(int quantity)
    {
        for (int i = 1; i <= quantity; i++)
        {
            float x = Random.Range(-10f, 10f);
            float z = Random.Range(-5f, 5f);
            float y = 0f;

            GameObject spawn = (GameObject)Instantiate(token, new Vector3(x, y, z), Quaternion.Euler(0, 0, 0));
            spawn.GetComponent<tokenControl>().lifeTime = i * delay;
        }
    }
}

