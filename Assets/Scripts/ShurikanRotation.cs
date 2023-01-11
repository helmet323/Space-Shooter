using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikanRotation : MonoBehaviour
{

    public float rotationSpeed;
    private float bulletHealth;


    void Update()
    {
        bulletHealth += Time.deltaTime;

        if (bulletHealth > 5)
        {
            Destroy(gameObject);
        }
        transform.Rotate (0, 0, -rotationSpeed * Time.deltaTime); 
    }


    void OnCollisionEnter2D(Collision2D col)
    {

        Destroy(gameObject);

        // if (col.gameObject.tag.Equals("Ground"))
        // {
        //     // impactEffect.SetBool("Collide", true);
        //     Destroy(gameObject);

        // }

        // if (col.gameObject.tag.Equals("Enemy"))
        // {
        //     // impactEffect.SetBool("Collide", true);
        //     Destroy(gameObject);
        // }

    }
}
