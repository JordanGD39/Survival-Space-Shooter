using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public GameObject shot;
    public GameObject explosionGO;
    public GameObject spawner;

    public EnemyExplosion explosionScript;
    public Player playerScript;
    public Spawner spawnerScript;

    public Transform shotSpawn;

    private Rigidbody rb;

    public float speed = 10f;
    public float forwardSpeed = 5f;
    public float timer = 0f;
    public float health = 20f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        spawnerScript = spawner.GetComponent<Spawner>();
        explosionScript = explosionGO.GetComponent<EnemyExplosion>();
        playerScript = player.GetComponent<Player>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.x > transform.position.x)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (player.transform.position.x < transform.position.x)
        {
            transform.position += -Vector3.right * speed * Time.deltaTime;
        }

        transform.position += -Vector3.forward * forwardSpeed * Time.deltaTime;

        timer += Time.deltaTime;
        if (!playerScript.runShips)
        {
            speed = 10;
            forwardSpeed = 5;
            if (timer > 0.8f)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.localRotation);
                timer = 0;
            }
        }
        else
        {
            forwardSpeed = 2.5f;
            if (transform.position.x > -25 && transform.position.x < 35)
            {
                speed = -10;
            }
            if (transform.position.x >= 35)
            {
                speed = 0;
            }

            if (transform.position.x <= -25)
            {
                speed = 0;
            }
        }

        if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        explosionScript.explode = true;
    }
}
