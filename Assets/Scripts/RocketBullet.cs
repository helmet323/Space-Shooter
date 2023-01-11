using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBullet : MonoBehaviour
{

    public GameObject[] target;
    public Vector3 dir;
    Rigidbody2D rb;
    public float speed;

    public float MissileMovement;

    public float destroyTimer;
    public GameObject bulletImpactEffect;

    private bool ifCollide = false;

    //sound
    public AudioSource impactSound;
    private float destroyDelay = 0.5f;
    private bool ifDead;


    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();

        impactSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        target = GameObject.Find("Player").GetComponent<PlayerStats>().enemies;

        if (target.Length > 0)
        {
            dir = (target[0].transform.position - transform.position).normalized;
            rb.velocity = new Vector2(dir.x * speed, dir.y * speed);

            float angle = AngleBetweenTwoPoints(transform.position, target[0].transform.position);

            transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle + 90));
        }

        if (ifCollide)
        {
            destroyTimer -= Time.deltaTime;
        }

        if (destroyTimer < 0)
        {
            Destroy(gameObject);
        }

        if (ifDead == true)
        {
            destroyDelay -= Time.deltaTime;
        }

        if (destroyDelay < 0)
        {
            Destroy(gameObject);
        }  

    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) 
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(bulletImpactEffect, transform.position, Quaternion.identity);
        impactSound.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        ifDead = true; 
    }
}
