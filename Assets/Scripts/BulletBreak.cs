using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletBreak : MonoBehaviour
{

    // public Animator impactEffect;
    public float bulletHealth = 0;
    public float destroyTimer;
    public GameObject bulletImpactEffect;

    private bool ifCollide = false;


    void Update()
    {
        bulletHealth += Time.deltaTime;

        if (bulletHealth > 5)
        {
            Destroy(gameObject);
        }


        if (ifCollide)
        {
            destroyTimer -= Time.deltaTime;
        }

        if (destroyTimer < 0)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(bulletImpactEffect, transform.position, Quaternion.identity);
        ifCollide = true;

    }

}
