using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    Transform player;
    Transform boss;
    Vector2 shotDirection;
    Rigidbody2D rb;
    public float speed;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        boss = GameObject.FindGameObjectWithTag("Boss").transform;
        if(boss.position.x >= player.position.x)
        {
            shotDirection = new Vector2(-1, 0);
        }
        else
        {
            shotDirection = new Vector2(1, 0);
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(shotDirection * speed, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Boss")
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
