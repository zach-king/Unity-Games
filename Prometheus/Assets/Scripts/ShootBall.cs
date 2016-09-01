using UnityEngine;
using System.Collections;
using Chronos;

public class ShootBall : MonoBehaviour {

    public GameObject projectile;
    public float speed = 20;
	
	// Update is called once per frame
	void Update () {
        // Check for input
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate projectile and give velocity
            GameObject clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            clone.GetComponent<Timeline>().rigidbody.velocity = transform.TransformDirection(Vector3.forward * speed);
        }
	}
}
