using UnityEngine;
using System.Collections;

public class Pacdot : MonoBehaviour
{ 
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "pacman")
            Destroy(gameObject);
    }
}
