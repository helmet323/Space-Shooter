using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Shoot : MonoBehaviour
{
    public GameObject rocketPrefab;

    public GameObject rocketPosition1;
    public GameObject rocketPosition2;

    public GameObject rocketPosition1Back;
    public GameObject rocketPosition2Back;

    //rocket 
    public float rocketReady;
    private float rocketReadySaver;
    public float rocketSpeed;

    //sound
    public AudioSource shootSound;

    //ammo
    public GameObject RocketAmmo;
    public int ammo;
    private int ammoSaver;
    public float ammoReload;
    private float ammoReloadSaver;

    //ButtonShoot
    public GameObject ShootButton;
    public bool ifShoot;

    // Start is called before the first frame update
    void Start()
    {
        rocketReadySaver = rocketReady;
        shootSound = GetComponent<AudioSource>();
        ammoSaver = ammo;
        ammoReloadSaver = ammoReload;
    }

    // Update is called once per frame
    void Update()
    {
        ifShoot = ShootButton.GetComponent<ButtonShoot>().ifShoot;

        rocketReady -= Time.deltaTime;

        //rocket bullet positions
        Vector3 difference1 = rocketPosition1.transform.position - rocketPosition1Back.transform.position;
        Vector3 difference2 = rocketPosition2.transform.position - rocketPosition2Back.transform.position;

        difference1.Normalize();
        difference2.Normalize();

        if (ifShoot == true && rocketReady < 0 && ammo >= 2)
        {   
            ammo -= 2;
            shootSound.Play();
            fireRocket1(difference1);
            fireRocket2(difference2);
            rocketReady = rocketReadySaver;
            ShootButton.GetComponent<ButtonShoot>().ifShoot = false;

        }
        
        if (Input.GetMouseButton(0))
        {
            ammoReload -= Time.deltaTime * 0.8f;
        }
        else
        {
            ammoReload -= Time.deltaTime * 2.4f;
        }

        if (ammo == 6)
        {
            RocketAmmo.gameObject.transform.GetChild(8).gameObject.SetActive(false);
            RocketAmmo.gameObject.transform.GetChild(9).gameObject.SetActive(false);
        }

        if (ammo == 4)
        {
            RocketAmmo.gameObject.transform.GetChild(10).gameObject.SetActive(false);
            RocketAmmo.gameObject.transform.GetChild(11).gameObject.SetActive(false);
        }

        if (ammo == 2)
        {
            RocketAmmo.gameObject.transform.GetChild(12).gameObject.SetActive(false);
            RocketAmmo.gameObject.transform.GetChild(13).gameObject.SetActive(false);
        }

        if (ammo == 0)
        {
            RocketAmmo.gameObject.transform.GetChild(14).gameObject.SetActive(false);
            RocketAmmo.gameObject.transform.GetChild(15).gameObject.SetActive(false);
        }


        if (ammoReload <= 0 && ammo <= 8)
        {
            ammoReload = 1f;
            ammo += 2;
            if (ammo == 8){
                RocketAmmo.gameObject.transform.GetChild(8).gameObject.SetActive(true);
                RocketAmmo.gameObject.transform.GetChild(9).gameObject.SetActive(true);
            }

            if (ammo == 6)
            {
                RocketAmmo.gameObject.transform.GetChild(10).gameObject.SetActive(true);
                RocketAmmo.gameObject.transform.GetChild(11).gameObject.SetActive(true);
            }

            if (ammo == 4)
            {
                RocketAmmo.gameObject.transform.GetChild(12).gameObject.SetActive(true);
                RocketAmmo.gameObject.transform.GetChild(13).gameObject.SetActive(true);
            }

            if (ammo == 2)
            {
                RocketAmmo.gameObject.transform.GetChild(14).gameObject.SetActive(true);
                RocketAmmo.gameObject.transform.GetChild(15).gameObject.SetActive(true);
            }
        }
    }


    void fireRocket1 (Vector2 direction)
    {
        GameObject b = Instantiate(rocketPrefab);
        b.transform.position = rocketPosition1.transform.position;
        b.GetComponent<Rigidbody2D>().velocity = direction * rocketSpeed;
    }

    void fireRocket2 (Vector2 direction)
    {
        GameObject b = Instantiate(rocketPrefab);
        b.transform.position = rocketPosition2.transform.position;
        b.GetComponent<Rigidbody2D>().velocity = direction * rocketSpeed;
    }
}
