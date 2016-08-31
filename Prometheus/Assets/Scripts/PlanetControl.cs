using UnityEngine;
using System.Collections;

public class PlanetControl : MonoBehaviour {
    [Range(0.01f, 2.0f)]
    public float rotationSpeed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // Check for rotation input
        if (Input.GetKey(KeyCode.A)) // rotating left
        {
            transform.Rotate(Vector3.up, rotationSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.D)) // rotating right
        {
            transform.Rotate(Vector3.up, -1 * rotationSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.Q)) // facing rotation left
        {
            transform.Rotate(Vector3.forward, rotationSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.E)) // facing rotation right
        {
            transform.Rotate(Vector3.forward, -1 * rotationSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.W)) // rotating forward
        {
            transform.Rotate(Vector3.right, rotationSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.S)) // rotating backward
        {
            transform.Rotate(Vector3.right, -1 * rotationSpeed, Space.World);
        }
    }
}
