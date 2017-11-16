using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //Debug.Log(Camera.main.fieldOfView);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Camera.main.orthographicSize += 3;
            //Debug.Log(Camera.main.fieldOfView);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Camera.main.orthographicSize -= 3;
            //Debug.Log(Camera.main.fieldOfView);
        }
    }
}
