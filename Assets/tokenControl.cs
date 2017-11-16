using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tokenControl : MonoBehaviour {

    public float lifeTime = 5f;
    public float lifeTimeInitial = 5f;
    public float touchCharge = 10f;
    public float touchRadius = 5f;
    public float touchLife = 0f;
    public TextMesh info;

    public GameObject forceObject;
    public GameObject container;
    public GameObject fill;
    public GameObject gameControl;

    // Use this for initialization
    void Start () {
        lifeTimeInitial = lifeTime;
        gameControl = GameObject.Find("GameControl");
    }
	
	// Update is called once per frame
	void Update () {
        lifeTime -= 1 * Time.deltaTime;

        info.text = "";//lifeTime.ToString("F0");

        if(lifeTime>0)       
        fill.transform.localScale = new Vector3(1 - (lifeTime / lifeTimeInitial), 0, 1 - (lifeTime / lifeTimeInitial));

        if (lifeTime <= 0)
        {
            Vector3 pos = transform.position;

            GameObject spawn = (GameObject)Instantiate(forceObject, pos, Quaternion.Euler(0, 0, 0));
            spawn.GetComponent<explosionEvent>().force = touchCharge;
            spawn.GetComponent<explosionEvent>().radius = touchRadius;
            spawn.GetComponent<explosionEvent>().life = touchLife;
            gameControl.GetComponent<scoreControl>().strike++;
            Debug.Log("Strike " + gameControl.GetComponent<scoreControl>().strike + "!");
            Destroy(gameObject);
        }
	}

    void OnMouseOver()
    {
        /*if (Input.GetMouseButton(0))
        {
            gameControl.GetComponent<scoreControl>().score += (lifeTimeInitial - lifeTime);
            gameControl.GetComponent<scoreControl>().defused++;
            Destroy(gameObject);
        }*/
    }

    /*void OnMouseDrag()
    {
        if (Input.GetMouseButton(0))
        {
            float distance = 7;
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }*/

}
