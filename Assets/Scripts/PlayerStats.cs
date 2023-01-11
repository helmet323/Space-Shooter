using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject[] enemies;

    public float playerHealth = 60f;
    public float playerDamage = 3f; //flat damage increase 
    public float playerDefense = 1f;
    public float playerSpeed = 5f;

    //damage links
    private float enemyDamage;


    // Start is called before the first frame update
    void Start()
    {
        // BossOneDamage = GameObject.Find("BOSS_ONE").GetComponent<QiyanaWeaponBoss>().BossOneDamage;
    }


    // Update is called once per frame
    void Update()
    {
        //enemies finder
        enemies = GameObject.FindGameObjectsWithTag ("Enemy");
        
        //target enemy
        List <GameObject> enemiesList = new List <GameObject> (enemies);
        enemiesList.RemoveAll(x => x == null);
        enemies = enemiesList.ToArray();

        if (playerHealth <= 0)
        {
            //disable gameobject to play animations
            Destroy(gameObject);
        }

        if (GameObject.Find("BOSS_ONE(Clone)") != null)
        {
             enemyDamage = GameObject.Find("BOSS_ONE(Clone)").GetComponent<QiyanaWeaponBoss>().BossOneDamage;
        }

        if (GameObject.Find("rockDrone(Clone)") != null)
        {
             enemyDamage = GameObject.Find("rockDrone(Clone)").GetComponent<RockDrone>().rockDroneDamage;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag.Equals("Enemy Bullet"))
        {
            float damageTaken = enemyDamage - playerDefense;
            if (damageTaken > 0)
            {
                playerHealth -= damageTaken;
            }
        }

        //boosts
        if (col.gameObject.name.Equals("Boost_Defense(Clone)"))
        {
            playerDefense += 1;
        }
        else if (col.gameObject.name.Equals("Boost_Speed(Clone)"))
        {
            playerSpeed += 0.2f;
        }
        else if (col.gameObject.name.Equals("Boost_Attack(Clone)"))
        {
            playerDamage += 1;
        }
        // else if (col.gameObject.name.Equals("Boost_Death"))
        // {
        //     poisonEffect = true;
        // }
        



    }
}
