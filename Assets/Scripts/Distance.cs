using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Distance : MonoBehaviour
{

    public int highScore;
    public static int distanceValue = 0;
    public int distanceValueReset;
    public static int distanceMilestone = 500;
    Text distance;

    //boss spawn
    public GameObject Boss_One;

    public GameObject BossSpawnPosition;

    //Scene 2
    public float sceneSwitchTimer;

    // Update is called once per frame

    void Start()
    {
        distance = GetComponent<Text> ();
        highScore = PlayerPrefs.GetInt ("highScore", highScore);
    }

    void FixedUpdate()
    {
        distanceValue += 1;
        distanceValueReset +=1;
    }

    void Update()
    {
        if (distanceValue > highScore){
            highScore = distanceValue;
        }


        distance.text = " " + distanceValue;

        if (distanceValueReset > distanceMilestone)
        {
            Instantiate(Boss_One, BossSpawnPosition.transform);
            distanceValueReset = 0;
        }

        PlayerPrefs.SetInt ("highScore", highScore);

    }
}


