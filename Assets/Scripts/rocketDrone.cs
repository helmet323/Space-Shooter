using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketDrone : MonoBehaviour
{
    //shoot stuff
    public GameObject[] targets;
    public GameObject rocket;
    public GameObject rocketPosition;
    public GameObject rocketPosition1;
    public GameObject rocketPosition2;
    public GameObject rocketPosition3;
    private GameObject player;

    public float reloadTimer;
    private float reloadTimerSaver;
    public float CycleTimer;

    //movement
    public float rocketDronespeed;
    public float offset;
    public float moveTimer;
    private float moveTimerSaver;

    Rigidbody2D rb;

    //rocket numbers
    private int rocketNumber;
    private bool RReady;
    private bool R1Ready;
    private bool R2Ready;
    private bool R3Ready;

    //sound
    public AudioSource shootSound;

    //pet skills
    public int Skill1Bool;
    public int Skill2Bool;
    public int Skill3Bool;
    public int Skill4Bool;

    public GameObject PetSkillButton;
    public bool IfPetSkill;

    //pet skill 4
    public Transform Skill4Pos1;
    public Transform Skill4Pos2;
    public Transform Skill4Pos3;
    public Transform Skill4Pos4;

    public GameObject shurikanPrefab;

    private float SkillTimer = 1;
    private float SkillTimerSaver;

    private float shurikanSpeed = 9;

    private float skill4Duration;

    


    void Start()
    {
        reloadTimerSaver = reloadTimer;
        moveTimerSaver = moveTimer;
        shootSound = GetComponent<AudioSource>();

        Skill1Bool = PlayerPrefs.GetInt ("Skill1Bool", Skill1Bool);
        Skill2Bool = PlayerPrefs.GetInt ("Skill2Bool", Skill2Bool);
        Skill3Bool = PlayerPrefs.GetInt ("Skill3Bool", Skill3Bool);
        Skill4Bool = PlayerPrefs.GetInt ("Skill4Bool", Skill4Bool);

        SkillTimerSaver = SkillTimer;

    }

    // Update is called once per frame
    void Update()
    {
        // pet skills
        IfPetSkill = PetSkillButton.GetComponent<PetSkillShoot>().IfPetSkill;

        SkillTimer -= Time.deltaTime;
        if (IfPetSkill == true && SkillTimer < 0)
        {

            PetSkillButton.GetComponent<PetSkillShoot>().IfPetSkill = false;

            if (Skill4Bool == 1)
            {
                skill4Duration = 5;
            }

            
            // if (Skill1Bool == 1)
            // {
            //     Instantiate();
            // }
            // if (Skill2Bool == 1)
            // {
            //     Instantiate();
            // }
            // if (Skill3Bool == 1)
            // {
            //     Instantiate();
            // }

            // if (skill4Duration < 5 && Skill4Bool == 1)
            // {
            //     Vector3 difference1 = Skill4Pos1.transform.position - transform.position;
            //     Vector3 difference2 = Skill4Pos2.transform.position - transform.position;
            //     Vector3 difference3 = Skill4Pos3.transform.position - transform.position;
            //     Vector3 difference4 = Skill4Pos4.transform.position - transform.position;

            //     difference1.Normalize();
            //     difference2.Normalize();
            //     difference3.Normalize();
            //     difference4.Normalize();
                
            //     transform.Rotate (0, 0, 240 * Time.deltaTime); 
            //     shurikanSpread(difference1, Skill4Pos1.position);
            //     shurikanSpread(difference2, Skill4Pos2.position);
            //     shurikanSpread(difference3, Skill4Pos3.position);
            //     shurikanSpread(difference4, Skill4Pos4.position);
        //     }

        // }

        //     SkillTimer = SkillTimerSaver;

        //     PetSkillButton.GetComponent<PetSkillShoot>().IfPetSkill = false;
        // }

        //  skill4Duration += Time.deltaTime;


        // if (Skill4Bool == 1 && SkillTimer < 0)
        // {
        //     skill4Duration = 0;

        }

        if (Skill4Bool == 1)
        {
            skill4Duration -= Time.deltaTime;
            if (skill4Duration > 0)
            {
                Vector3 difference1 = Skill4Pos1.transform.position - transform.position;
                Vector3 difference2 = Skill4Pos2.transform.position - transform.position;
                Vector3 difference3 = Skill4Pos3.transform.position - transform.position;
                Vector3 difference4 = Skill4Pos4.transform.position - transform.position;

                difference1.Normalize();
                difference2.Normalize();
                difference3.Normalize();
                difference4.Normalize();
                
                transform.Rotate (0, 0, 360 * Time.deltaTime); 
                shurikanSpread(difference1, Skill4Pos1.position);
                shurikanSpread(difference2, Skill4Pos2.position);
                shurikanSpread(difference3, Skill4Pos3.position);
                shurikanSpread(difference4, Skill4Pos4.position);
            }

            Debug.Log(skill4Duration);
        }

        targets = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerStats>().enemies;

        player = GameObject.FindGameObjectsWithTag("Player")[0];

        //rocket pattern
        reloadTimer -= Time.deltaTime;

        if (reloadTimer < 0 && targets.Length > 0)
        {

            if (rocketNumber == 0)
            {
                rocketNumber += 1;
                RReady = true;
                reloadTimer = reloadTimerSaver;
            }
            else if(rocketNumber == 1)
            {
                rocketNumber += 1;
                R1Ready = true;
                reloadTimer = reloadTimerSaver;
            }
            else if(rocketNumber == 2)
            {
                rocketNumber += 1;
                R2Ready = true;
                reloadTimer = reloadTimerSaver;
            }
            else if(rocketNumber == 3)
            {
                rocketNumber = 0;
                R3Ready = true;
                reloadTimer = reloadTimerSaver + CycleTimer;
            }

        }

        if (RReady == true)
        {
            shootSound.Play();
            Instantiate(rocket, rocketPosition.transform);
            RReady = false;
        }
        else if (R1Ready == true)
        {
            shootSound.Play();
            Instantiate(rocket, rocketPosition1.transform);
            R1Ready = false;
        }
        else if (R2Ready == true)
        {
            shootSound.Play();
            Instantiate(rocket, rocketPosition2.transform);
            R2Ready = false;
        }
        else if (R3Ready == true)
        {
            shootSound.Play();
            Instantiate(rocket, rocketPosition3.transform);
            R3Ready = false;
        }


        //drone movement
        Vector3 difference = player.transform.position - transform.position;
        
        difference.Normalize();

        moveTimer -= Time.deltaTime;

        if (moveTimer < 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = difference * rocketDronespeed;
            moveTimer = moveTimerSaver;
        }
        
        
    }

    void shurikanSpread(Vector2 direction, Vector3 position)
    {
        GameObject b = Instantiate(shurikanPrefab) as GameObject;
        b.transform.position = position;
        b.GetComponent<Rigidbody2D>().velocity = direction * shurikanSpeed;
    }
}
