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

    public float speed;
    public float forwardSpeed;
    public float timer;
    public float health = 20f;

    // Start is called before the first frame update
    void Start()
    {
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
        float distance = (transform.position - player.transform.position).magnitude;

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
            if (transform.position.z < 35)
            { 
                forwardSpeed = -2;
            }
            if (transform.position.x > -25 && transform.position.x < 35)
            {
                speed = -10;
            }
            if (transform.position.z >= 35)
            {
                forwardSpeed = 5;
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

        if (health <= 0f || Input.GetKey(KeyCode.Y))
        {
            Die();
        }
    }

    public void Die()
    {
        explosionScript.explode = true;
    }
}
