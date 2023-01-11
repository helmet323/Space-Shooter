using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDroneSpawner : MonoBehaviour
{
    public GameObject rockDrone;
    public GameObject spawnPos1;
    public GameObject spawnPos2;

    public float spawnTimer;
    private float spawnTimerSaver;

    public float spawnCap;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimerSaver = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0 && spawnCap >= 0)
        {
            spawnCap -= 1;
            Instantiate(rockDrone, spawnPos1.transform);
            Instantiate(rockDrone, spawnPos2.transform);
            spawnTimer = spawnTimerSaver;
        }
    }
}
