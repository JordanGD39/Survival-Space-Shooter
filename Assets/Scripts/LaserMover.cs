using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMover : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
    }
    
    void Update()
    {
        if (transform.position.z > 50 || transform.position.z < -50)
        {
            Destroy(gameObject);
        }
    }
}
