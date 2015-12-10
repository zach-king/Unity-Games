using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour {
    // Current movement direction
    // by default it moves to the right
    Vector2 dir = Vector2.right;
    List<Transform> tail = new List<Transform>();
    bool ate = false, gameOver = false;

    // Tail prefab
    public GameObject tailPrefab;
    public GameObject foodPrefab;
    public Text loseText;

    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    // Configurable variables
    public int startingLength = 5;

    // Use this for initialization
    void Start () {
        // Move the snake every 300ms
        InvokeRepeating("Move", 0.2f, 0.2f);

        // Spawn the first food instance
        Spawn();

        // Set snake to proper starting length
        for (int i = 0; i < startingLength; i++)
        {
            ate = true;
            Move();
        }

        // Disable the 'You Lose' text
        loseText.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        // Move in a new direction
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = Vector2.left;
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = Vector2.down;

        if (gameOver)
            if (Input.GetKey(KeyCode.R))
                SceneManager.LoadScene("Game");
	}

    void Move()
    {
        if (gameOver)
            return;

        // Save the current position (gap)
        Vector2 gap = transform.position;

        // Move head into new direction
        transform.Translate(dir);

        // Did we eat something?
        if (ate)
        {
            // Load prefab into world
            GameObject g = (GameObject)Instantiate(tailPrefab, gap, Quaternion.identity);

            // Keep track of it in our tail list
            tail.Insert(0, g.transform);

            // Reset the flag
            ate = false;
        }

        // Do we have a Tail?
        if (tail.Count > 0)
        {
            // Move last tail element to where head was
            tail.Last().position = gap;

            // Add to front of list, remove from back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Did we hit food?
        if (col.name.StartsWith("Food"))
        {
            // Get longer in next Move() call
            ate = true;

            // Create a new food instance
            Spawn();

            // Destroy food instance
            Destroy(col.gameObject);
        }
        else // Collided with tail or border
        {
            // 'You Lose' Screen
            loseText.enabled = true;

            // Game Over
            gameOver = true;

            //Debug.Log(col.name);
        }
    }

    // Spawn one piece of food
    void Spawn()
    {
        // x position between left and right border
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);

        // y position between top and bottom border
        int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

        // Instantiate the food at (x, y)
        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity); // Quaternion.identity = default rotation
    }
}
