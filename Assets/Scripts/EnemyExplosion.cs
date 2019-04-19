using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    public SphereCollider sphereCollider;

    public Animator anim;

    public GameObject spawner;
    public GameObject enemy;
    public GameObject player;

    public Player playerScript;
    public Spawner spawnerScript;

    public bool explode = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
        transform.localScale = new Vector3(0, 0, 0);
        anim = GetComponent<Animator>();
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        spawnerScript = spawner.GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (explode)
        {
            anim.SetTrigger("Explosion");
            StartCoroutine("ExplosionFunction");
        }
        if (transform.localScale.x > 6)
        {
            Destroy(gameObject);
            Destroy(enemy);
            playerScript.score += 100;
            if (spawnerScript.waitTime > 2)
            {
               spawnerScript.waitTime -= 0.5f;
            }
        }
    }

    public IEnumerator ExplosionFunction()
    {
        sphereCollider.radius *= 1.05f;
        transform.localScale = new Vector3(sphereCollider.radius, sphereCollider.radius, sphereCollider.radius);
        yield return new WaitForSeconds(0.1f);
    }
}
