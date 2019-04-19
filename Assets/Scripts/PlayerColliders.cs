using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliders : MonoBehaviour
{
    public GameObject player;

    public Player playerScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "EnemyLaser")
        {
            playerScript.Damage(10);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "PowerUp")
        {
            playerScript.runShips = true;
            playerScript.score += 100;
            Destroy(col.gameObject);
        }
    }
}
