using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantPlanet : MonoBehaviour
{
    public Transform PlanetPosition;
    private Rigidbody2D rb;

    //size RNG
    public float size;
    public float sizeRangeFloor;
    public float sizeRangeCeil;

    //rotation RNG
    public float rotation;
    public float rotationRangeFloor;
    public float rotationRangeCeil;

    //speed RNG
    public float planetSpeed;
    public float planetSpeedFloor;
    public float planetSpeedCeil;

    //health
    private float planetHealth;
    public float damageTake;
    public float planetHealthScale;

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        PlanetPosition = gameObject.transform;

        //size
        size = Random.Range(sizeRangeFloor, sizeRangeCeil);
        transform.localScale = new Vector3(size, size, 1);

        //rotation
        rotation = Random.Range(rotationRangeFloor, rotationRangeCeil);

        //speed
        planetSpeed = Random.Range(planetSpeedFloor, planetSpeedCeil);

        planetHealth = size * planetHealthScale;
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0.0f, -planetSpeed);
        if (PlanetPosition.position.y < -10){
            Destroy(gameObject);
        }

        transform.Rotate (0,0,rotation*Time.deltaTime); 
        
        if (planetHealth < 0){
            Destroy(gameObject);
            //add animations and stuff later
        }

    }

    //health
    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag.Equals("Bullet")){
            planetHealth -= damageTake;
        }
    }
}
