using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseControl : MonoBehaviour {

    public GameObject forceObject;
    public GameObject tokenObject;
    public float touchCharge = 5f;
    public float touchRadius = 5f;
    public float touchLife = 1f;

    public bool lmb_explosion;
    public bool lmb_implosion;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //LMB

        if (lmb_explosion)
        {
            if (Input.GetMouseButton(0))
            {
                touchCharge += 10 * Time.deltaTime;
            }

            if (Input.GetMouseButtonUp(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit)/* && fireReady >= timeToFireReady*/)
                {
                    Vector3 pos = hit.point;
                    pos.y = -1;
                    GameObject spawn = (GameObject)Instantiate(forceObject, pos, Quaternion.Euler(0, 0, 0));
                    spawn.GetComponent<explosionEvent>().force = touchCharge;
                    //spawn.GetComponent<explosionEvent>().radius = touchCharge;
                    spawn.GetComponent<explosionEvent>().life = touchLife;
                    //fireReady = 0;
                }

                touchCharge = 1f;
            }
        }
        else if (lmb_implosion)
        {
 
            if (Input.GetKeyDown(KeyCode.Z))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 pos = hit.point;
                    pos.y = -1;
                    GameObject spawn = (GameObject)Instantiate(forceObject, pos, Quaternion.Euler(0, 0, 0));
                    spawn.GetComponent<explosionEvent>().force = -0.1f;
                    spawn.GetComponent<explosionEvent>().radius = 5f;
                    spawn.GetComponent<explosionEvent>().life = 1000f;
                }
            }
        }

        //RMB

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 pos = hit.point;
                pos.y = 0f;
                GameObject spawn = (GameObject)Instantiate(tokenObject, pos, Quaternion.Euler(0, 0, 0));
                spawn.GetComponent<tokenControl>().lifeTime = 60f;
            }
        }

    }
}
