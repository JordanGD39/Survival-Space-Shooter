using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timer;
    public float spawnItemTimer;
    public float waitTime = 6;

    public GameObject enemyPrefab;
    public GameObject itemPrefab;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        spawnItemTimer += Time.deltaTime;
        if (timer >= waitTime)
        {
            timer = 0;
            Instantiate(enemyPrefab, new Vector3(Random.Range(-25, 35), 0, 40), new Quaternion(0, 180, 0, transform.rotation.w));
        }

        if (spawnItemTimer >= 60)
        {
            Instantiate(itemPrefab, new Vector3(Random.Range(-25, 35), 0, Random.Range(0, 30)), Quaternion.Euler(90, 0, 0));
            spawnItemTimer = 0;
        }
    }
}
