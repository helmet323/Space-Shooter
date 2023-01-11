using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDrone : MonoBehaviour
{
    public GameObject rockBulletPosition;
    public GameObject rockBullet;
    public GameObject player;

    public float RockDroneHealth;

    public float rockReloadTime;
    private float rockReloadTimeSaver;
    public float rockBulletSpeed;

    public float rockDroneDamage;

    //movement
    public float speed;
    public float VerticalSpeed = 0.5f;

    public float horizontalMoveCeil;
    public float horizontalMoveFloor;

    public float verticalMoveCeil;
    public float verticalMoveFloor;

    private float playerDamage;

    public float moveTimer;
    private float moveTimerSaver;

    Rigidbody2D rb;

    public int deathTimer = 5;



    // Start is called before the first frame update
    void Start()
    {
        rockReloadTimeSaver = rockReloadTime;

        //drops script link
        playerDamage = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerStats>().playerDamage;

        //movement
        moveTimerSaver = moveTimer;
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
    
        if (RockDroneHealth <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            // gameObject.GetComponent<RockDrone>().enabled = false;
            gameObject.GetComponent<EmptyScript>().enabled = false;
            deathTimer -= 1;

            if (deathTimer < 0)
            {
                Destroy(gameObject);
            }

        }

        //auto move (AI)

        if (transform.position.y > verticalMoveCeil)
        {
            Vector3 direction = player.transform.position - transform.position;
            
            direction.Normalize();

            moveTimer -= Time.deltaTime;

            if (moveTimer < 0)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = direction * speed;
                moveTimer = moveTimerSaver;
            }
        }
        else {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            transform.position = transform.position + (transform.right * speed * Time.deltaTime);
            if (transform.position.x > horizontalMoveCeil - 0.1)
            {
                speed = -speed;
            }
            else if (transform.position.x < horizontalMoveFloor + 0.1)
            {
                speed = -speed;
            }

            transform.position = transform.position + (transform.up * VerticalSpeed * Time.deltaTime);
            if (transform.position.y > verticalMoveCeil)
            {
                VerticalSpeed = -VerticalSpeed;
            }
            else if (transform.position.y < verticalMoveFloor)
            {
                VerticalSpeed = -VerticalSpeed;
            }
        }



        rockReloadTime -= Time.deltaTime;

        Vector3 difference = rockBulletPosition.transform.position - transform.position;


        if (rockReloadTime < 0){
            fireBullet(difference, rockBulletPosition.transform.position);
            rockReloadTime = rockReloadTimeSaver;
        }
    }

    void fireBullet(Vector2 direction, Vector3 position)
    {
        GameObject b = Instantiate(rockBullet) as GameObject;
        b.transform.position = position;
        b.GetComponent<Rigidbody2D>().velocity = direction * rockBulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player Bullet"))
        {
            RockDroneHealth -= playerDamage;
        }
    }
}
