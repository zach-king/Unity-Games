using UnityEngine;
using System.Collections;

public class PacmanMove : MonoBehaviour {
    public float speed = 0.4f;

    Vector2 destination = Vector2.zero;

	// Use this for initialization
	void Start () {
        destination = transform.position;
	}

    void FixedUpdate()
    {
        // Move towards destination
        Vector2 p = Vector2.MoveTowards(transform.position, destination, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        // Check for input if not moving
        if ((Vector2)transform.position == destination)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                destination = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.DownArrow) && valid(Vector2.down))
                destination = (Vector2)transform.position + Vector2.down;
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                destination = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.LeftArrow) && valid(Vector2.left))
                destination = (Vector2)transform.position + Vector2.left;
        }

        // Animation
        Vector2 dir = destination - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    bool valid(Vector2 dir)
    {
        // Cast line one unit in dir to check for walls
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
}
