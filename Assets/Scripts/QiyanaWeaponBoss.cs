using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QiyanaWeaponBoss : MonoBehaviour
{

    public float bossRotation;
    public float rotationTimer;
    private float rotationTimerSaver;


    //Boss Call for help
    public GameObject LilQiyQiy;
    [SerializeField] private bool QiyQiySpawn = true;
    public Transform QiySpawnPos1;
    public Transform QiySpawnPos2;
    public float QiyQiySpawnHealth;

    //boss bullet positions
    public Transform BBP1;
    public Transform BBP2;
    public Transform BBP3;
    public Transform BBP4;

    public GameObject BossBulletPrefab;
    public float BossBulletSpeed;

    public float BossReloadTime;
    private float BossReloadTimeSaver;

    public float BossHealth;

    public float phaseTime;
    private float phaseTimeSaver;

    public float platformSprayDuration;
    private float platformSprayDurationSaver;

    [SerializeField] private bool BossAttackPhase;

    private float BossShield;

    //link to player
    private float playerDamage;
    public float BossOneDamage = 3;


    void Start()
    {
        BossReloadTimeSaver = BossReloadTime;
        phaseTimeSaver = phaseTime;
        platformSprayDurationSaver = platformSprayDuration;
        rotationTimer = rotationTimerSaver;
        rotationTimer = 0;

        playerDamage = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerStats>().playerDamage;
        
    }
    // Update is called once per frame
    void Update()
    {
        //rotation
        // rotationTimer += Time.deltaTime;

        // if (rotationTimer > rotationTimerSaver)
        // {
        //     bossRotation -= bossRotation;
        //     rotationTimer = 0;
        // }

        transform.Rotate (0, 0, bossRotation * Time.deltaTime); 

        if (BossAttackPhase == true)
        {

            //shooting
            BossReloadTime -= Time.deltaTime;

            //phases
            phaseTime -= Time.deltaTime;

            //Boss bullet positions
            Vector3 difference1 = BBP1.position - transform.position;
            Vector3 difference2 = BBP2.position - transform.position;
            Vector3 difference3 = BBP3.position - transform.position;
            Vector3 difference4 = BBP4.position - transform.position;

            difference1.Normalize();
            difference2.Normalize();
            difference3.Normalize();
            difference4.Normalize();

            if (BossReloadTime < 0)
            {
                fireBullet(difference1, BBP1.position);
                fireBullet(difference2, BBP2.position);
                fireBullet(difference3, BBP3.position);
                fireBullet(difference4, BBP4.position);
                BossReloadTime = BossReloadTimeSaver;
            }
        }

        if (BossHealth < QiyQiySpawnHealth && QiyQiySpawn == true)
        {
            SpawnQiyQiy(QiySpawnPos1.position);
            SpawnQiyQiy(QiySpawnPos2.position);
            QiyQiySpawn = false;
            BossAttackPhase = false;
            BossShield = 20;
        }

        if (BossShield < 0){
            BossAttackPhase = true;
        }

        if (phaseTime < 0)
        {
            BossReloadTime = 0;
            platformSprayDuration -= Time.deltaTime;

            if (platformSprayDuration < 0)
            {
                phaseTime = phaseTimeSaver;
                platformSprayDuration = platformSprayDurationSaver;
            }
        }


        if (BossHealth < 0)
        {
            Destroy(gameObject);
        }

        
    }

    void fireBullet(Vector2 direction, Vector3 position)
    {
        GameObject b = Instantiate(BossBulletPrefab) as GameObject;
        b.transform.position = position;
        b.GetComponent<Rigidbody2D>().velocity = direction * BossBulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D col){

        if (col.gameObject.tag.Equals("Player Bullet"))
        {
            BossHealth -= playerDamage;
            BossShield -= playerDamage;
        }

    }

    void SpawnQiyQiy(Vector3 position)
    {
        GameObject q = Instantiate(LilQiyQiy) as GameObject;
        q.transform.position = position;
    }

}
