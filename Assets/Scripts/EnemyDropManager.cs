using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject defenseBoost;
    public GameObject speedBoost;
    public GameObject attackBoost;

    public int dropChanceCeil;
    public float defenseDropChance = 2;
    public float speedDropChance = 5;
    public float attackDropChance = 7;

    private float randomNum;
    private float totalDropChance;

    // Start is called before the first frame update
    void Start()
    {
        totalDropChance = defenseDropChance + speedDropChance + attackDropChance;
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerStats>().enemies;
        
        List <GameObject> enemiesList = new List <GameObject> (enemies);

        for (int i = 0; i < enemies.Length; i++)
        {
            
            if (enemiesList[i].GetComponent<EmptyScript>().enabled == false) //disable on rockdrone
            {

                randomNum = Random.Range(0, dropChanceCeil);
                enemiesList[i].GetComponent<EmptyScript>().enabled = true;
                Debug.Log(randomNum);

                if (randomNum < totalDropChance)
                {
                    if (randomNum > 0 && randomNum <= defenseDropChance)
                    {
                        Instantiate(defenseBoost, enemiesList[i].transform.position, Quaternion.identity);
                        Destroy(enemiesList[i].gameObject);
                    }
                    else if(randomNum <= defenseDropChance + speedDropChance)
                    {
                        Instantiate(speedBoost, enemiesList[i].transform.position, Quaternion.identity);
                        Destroy(enemiesList[i].gameObject);
                    }
                    else if (randomNum <= totalDropChance)
                    {
                        Instantiate(attackBoost, enemiesList[i].transform.position, Quaternion.identity);
                        Destroy(enemiesList[i].gameObject);
                    }
                }
                else
                {
                    Destroy(enemiesList[i].gameObject);
                }

            }
        }

        enemies = enemiesList.ToArray();

    }
}
