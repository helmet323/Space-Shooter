using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuiciderSpawner : MonoBehaviour
{

    public GameObject suiciders;

    public float spawnTimer;
    public float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTimer)
        {
            Instantiate(suiciders, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
