using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public SphereCollider sphereCollider;
    public Animator anim;
    public GameObject player;
    public AudioSource destroyed;

    public bool explode = false;
    public bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);
        sphereCollider = gameObject.GetComponentInChildren<SphereCollider>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (explode)
        {
            if (!done)
            {
                destroyed.Play();
                done = true;
            }
            anim.SetTrigger("Explosion");
            StartCoroutine("ExplosionFunction");
        }
        if (sphereCollider.radius > 6)
        {
            Destroy(gameObject);
            Destroy(player);
        }
    }

    public IEnumerator ExplosionFunction()
    {
        sphereCollider.radius *= 1.05f;
        transform.localScale = new Vector3(sphereCollider.radius, sphereCollider.radius, sphereCollider.radius);
        yield return new WaitForSeconds(0.1f);
    }
}
