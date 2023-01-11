using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boosts : MonoBehaviour
{
    public string Boost_Name;

    public float boostRotation;
    public float fallSpeed;

    void Start()
    {
        Boost_Name = gameObject.name;
        Debug.Log(Boost_Name);
    }

    void Update()
    {
        transform.Rotate (0, boostRotation * Time.deltaTime, 0); 
        transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed * Time.deltaTime, transform.position.z);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        //add animation stuff with boost name
        Destroy(gameObject);

    }
}
