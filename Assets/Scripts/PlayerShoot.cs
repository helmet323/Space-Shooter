using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject bulletPrefabBlue;
    public GameObject bulletPosition;
    public GameObject player;

    public float bulletSpeed;
    public float shotgunSpeed;

    public float reloadTime;
    private float reloadTimeSaver;
    

    //shotgun reload
    public int shotgunReady = 3;
    private int shotgunReadySaver;

    //shotgun bullet positions
    public GameObject BP1;
    public GameObject BP2;
    public GameObject BP3;
    public GameObject BP4;

    //ButtonShoot
    public GameObject ShootButton;
    public bool ifShoot;

    //sound
    public AudioSource shootSound;


    void Start()
    {
        reloadTimeSaver = reloadTime;
        shotgunReadySaver = shotgunReady;
        shootSound = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        ifShoot = ShootButton.GetComponent<ButtonShoot>().ifShoot;

        reloadTime -= Time.deltaTime;

        Vector3 difference = bulletPosition.transform.position - player.transform.position;

        //shotgun bullet positions
        Vector3 difference1 = BP1.transform.position - player.transform.position;
        Vector3 difference2 = BP2.transform.position - player.transform.position;
        Vector3 difference3 = BP3.transform.position - player.transform.position;
        Vector3 difference4 = BP4.transform.position - player.transform.position;

        difference.Normalize();
        difference1.Normalize();
        difference2.Normalize();
        difference3.Normalize();
        difference4.Normalize();

        if (ifShoot == true && reloadTime  < 0)
        {   
            shootSound.Play();
            if (shotgunReady < 0){  
                fireBulletSpread(difference1);
                fireBulletSpread(difference2);
                fireBulletSpread(difference3);
                fireBulletSpread(difference4);
                shotgunReady = shotgunReadySaver;
            } else {
                fireBullet(difference);
                reloadTime = reloadTimeSaver;
                shotgunReady -= 1;
            }
            ShootButton.GetComponent<ButtonShoot>().ifShoot = false;
        }
    }

        void fireBullet(Vector2 direction)
        {
            GameObject b = Instantiate(bulletPrefab);
            b.transform.position = bulletPosition.transform.position;
            b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }

        void fireBulletSpread (Vector2 direction)
        {

            GameObject b = Instantiate(bulletPrefabBlue);
            b.transform.position = bulletPosition.transform.position;
            b.GetComponent<Rigidbody2D>().velocity = direction * shotgunSpeed;
        }

}

