using UnityEngine;
using System.Collections;

public class EndZone : MonoBehaviour {
    // Player collided with end zone?
    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Player")
        {
            // Perform end-game action...
            Debug.Log("You won!");
        }
    }
}
