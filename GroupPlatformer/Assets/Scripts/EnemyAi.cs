using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    // Reference for my waypoints
    public List<Transform> points;
    // The int value for my indexed list
    public int nextId;
    // Declare a int to help is change our nextId
    private int IdChangeValue = 1;
    // Sets our speed of the enemy
    public float speed = 2;
    public Transform player;



    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, player.position) < 5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            MoveToNextPoint();
        }
    }

    void MoveToNextPoint()
    {
        // Declare and set a transform to our next point
        Transform goalPoint = points[nextId];
        // Flip the enemy via the transform to look at the next points direction
        // Might need to change based off the spirtes natural face
        if (goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        // Move the enemy towards our point
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        // Check the distance between the enemy and the goalPoint to trigger the next point
        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            // Check if we are at the end of line make our change value -1
            if (nextId == points.Count - 1)
            {
                IdChangeValue = -1;
            }
            // Check is we are at the start of our line make our change value 1
            if (nextId == 0)
            {
                IdChangeValue = 1;
            }
            nextId += IdChangeValue;
        }
    }
}
    
