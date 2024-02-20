using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidAndWaveSpawner : MonoBehaviour
{
    static int ObstacleInt;

    enum ObstacleChoice //Enum assigns values to Squid and Wave (0, 1)
    {
        Squid,
        Wave
    };

    //Stores next and last spawntimes
    float LastSpawnTime = -500f; 
    float NextSpawnTime = 3;

    public Object SquidPrefab;
    public Object WavePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ObstacleInt = Random.Range(0, 2); //sets obstacle int to be 1 or 0 

        if(ObstacleInt == (int)ObstacleChoice.Squid) //checks if obstacle int = squid's value (0)
        {
            if (Time.time - LastSpawnTime > NextSpawnTime)
            {
                //Checks if spawntime is at the correct value and instantiates squid prefab

                NextSpawnTime = Random.Range(5, 10);
                LastSpawnTime = Time.time;
                Instantiate(SquidPrefab);
            }
        }
        else //ObstacleInt = 1 (wave value) 
        {
            if (Time.time - LastSpawnTime > NextSpawnTime)
            {
                //Checks if spawntime is at the correct value and instantiates squid prefab

                NextSpawnTime = Random.Range(5, 10);
                LastSpawnTime = Time.time;
                Instantiate(WavePrefab);
            }
        }
        
        
    }
}
