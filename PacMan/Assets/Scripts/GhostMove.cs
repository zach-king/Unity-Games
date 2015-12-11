using UnityEngine;
using System.Collections;

public class GhostMove : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 0.3f;

    int currentWaypoint;

    void FixedUpdate()
    {
        if (transform.position != waypoints[currentWaypoint].position)
        {
            Vector2 pos = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(pos);
        }
        else // Waypoint has been reached. Get a new one
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;

        // Animation
        Vector2 dir = waypoints[currentWaypoint].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "pacman")
            Destroy(col.gameObject); // Game over
    }
}
