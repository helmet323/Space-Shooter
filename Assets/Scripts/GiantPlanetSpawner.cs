using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantPlanetSpawner : MonoBehaviour
{
    public GameObject giantPlanet;
    public float range;

    public float spawnTimer;
    private float spawnTimerSaver;
    void Start(){
        spawnTimerSaver = spawnTimer;
    }
    // Update is called once per frame
    void Update()
    {   
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0){
            Vector3 position = new Vector3(Random.Range(-range, range), transform.position.y, 1);
            Instantiate(giantPlanet, position, Quaternion.identity);
            spawnTimer = spawnTimerSaver;

        }



    }
}
