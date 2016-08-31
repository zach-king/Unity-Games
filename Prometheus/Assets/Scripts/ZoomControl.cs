using UnityEngine;
using System.Collections;

public class ZoomControl : MonoBehaviour {
    [Range(0.01f, 3.0f)]
    public float zoomSpeed = 1.0f;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Camera.main.fieldOfView += zoomSpeed;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Camera.main.fieldOfView -= zoomSpeed;
        }
	}
}
