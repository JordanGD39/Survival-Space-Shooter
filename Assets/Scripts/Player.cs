using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public GameObject explosionGO;

    public Explosion explosionScript;

    public Animator anim;

    public Text scoreText;
    public Text timerText;
    public Image healthBar;

    public float health = 100f;
    public float timer = 0;
    public float runTimer = 0;
    public float invincibleTimer = 0;

    public bool invincible = false;
    public bool runShips = false;

    public int score = 0;
    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        explosionGO = GameObject.FindGameObjectWithTag("Explosion");
        explosionScript = explosionGO.GetComponent<Explosion>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("invincible", invincible);
        if (dead)
        {
            timer += Time.deltaTime;
        }
        invincibleTimer += Time.deltaTime;
        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + timer.ToString("F2");
        if (health <= 0f || Input.GetKey(KeyCode.Y))
        {
            Die();
        }

        if (timer > 60)
        {
            if (health >= 100)
            {
                score += 1000;
                timer = 0;
            }
            if (health < 100)
            {
                score += 100;
                timer = 0;
            }
        }

        if (invincible)
        {
            if (invincibleTimer > 3)
            {
                invincible = false;
            }
        }

        if (runShips)
        {
            runTimer += Time.deltaTime;

            if (runTimer >= 15)
            {
                runShips = false;
                runTimer = 0;
            }
        }

        float calcHealth = health / 100;
        healthBar.transform.localScale = new Vector3(Mathf.Clamp(calcHealth, 0, 1), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    public void Damage(int damage)
    {
        if (!invincible)
        {
            health -= damage;
            invincibleTimer = 0;
            invincible = true;
        }
    }

    void Die()
    {
        explosionScript.explode = true;
        Destroy(gameObject.GetComponent<PlayerController>());
        dead = true;
    }
}
