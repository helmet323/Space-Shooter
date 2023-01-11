using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    private int randNum;
    Text tip;
    private float loadTime;

    // Start is called before the first frame update
    void Start()
    {
        tip = GetComponent<Text>();
        randNum = Random.Range(1, 5);
        loadTime = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        loadTime -= Time.deltaTime;

        if (loadTime < 0)
        {
            SceneManager.LoadScene(2);
        }
        

        if (randNum == 1)
        {
            tip.text = "Try dodging to survive";
        }
        else if(randNum == 2)
        {
            tip.text = "ROCKET SHIP: Don't shoot to reload faster";
        }
        else if(randNum == 3)
        {
            tip.text = "Destroy the enemy to progress";
        }
        else if(randNum == 4)
        {
            tip.text = "If your HP goes below 0, you die";
        }

        
    }
}
