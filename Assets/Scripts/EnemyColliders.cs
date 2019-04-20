using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliders : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;

    public EnemyAI enemyScript;
    public Player playerScript;

    void Start()
    {
        enemyScript = enemy.GetComponent<EnemyAI>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("PlayerLaser"))
        {
            enemyScript.health -= 10;
            playerScript.score += 5;
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("PlayerCol"))
        {
            enemyScript.health -= 20;
            playerScript.Damage(50);
        }
    }
}
