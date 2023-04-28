using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public int bossHealth = 10;
    public bool phase2 = false;
    public bool phase3 = false;
    public bool isDead = false;
    public float attackRange;
    Transform player;
    PlayerManager playerManager;
    float speed;
    public bool isFlipped;
    public GameObject projectile;
    public Transform shotLocation;
    public float timer;
    public float coolDown;
    public GameObject projectile2;

    // Start is called before the first frame update
    void Start()
    {
        PlayerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossHealth < 7 && bossHealth > 3)
        {
            phase2 = true;
            attackRange = 6;
            speed = 3;
            Debug.Log("Phase 2");
        }
        else if (bossHealth < 4 && bossHealth >= 1)
        {
            phase2 = false;
            phase3 = true;
            attackRange = 8;
            speed = 3;
            Debug.Log("Phase 3");
        }
        else if (bossHealth <= 0)
        {
            phase3 = false;
            isDead = true;
            Debug.Log("isDead");
        }
        timer += Time.deltaTime;
    }

    public void Projectlileshoot()
    {
        if (timer > coolDown)
        {
            if (phase2)
            {
                GameObject clone = Instantiate(projectile, shotLocation.position, Quaternion.identity);
                timer = 0;
            }
            else if (phase3)
            {
                GameObject clone = Instantiate(projectile, shotLocation.position, Quaternion.identity);
                timer = 0;
            }
        }
    }
    public void LookAtPlayer()
    
        {
            Vector3 flipped = transform.localScale;
            flipped.z *= -1f;

            if (transform.position.x > player.position.x && isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0, 180, 0);
                isFlipped = false;
            }
            if (transform.position.x < player.position.x && !isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0, 180, 0);
                isFlipped = true;

            }
        }
          private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "player")
            {
                PlayerManager.TakeDamage();
            }
        }
    }

