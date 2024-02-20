using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelAndCannonBallSpawner : MonoBehaviour
{
    static int ObstacleInt;

    enum ObstacleChoice //Enum assigns values to Barrel and CannonBall (0, 1)
    {
        Barrel,
        CannonBall
    };

    float LastSpawnTime = -500f;
    float NextSpawnTime = 3;

    public Object CannonBallPrefab;
    public Object BarrelPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ObstacleInt = Random.Range(0, 2);

        if (ObstacleInt == (int)ObstacleChoice.Barrel) //checks if obstacle int = barrel's value (0)
        {
            if (Time.time - LastSpawnTime > NextSpawnTime)
            {
                NextSpawnTime = Random.Range(5, 10);
                LastSpawnTime = Time.time;
                Instantiate(BarrelPrefab);
            }
        }
        else //ObstacleInt = 1 (cannonball value) 
        {
            if (Time.time - LastSpawnTime > NextSpawnTime)
            {
                NextSpawnTime = Random.Range(5, 10);
                LastSpawnTime = Time.time;
                Instantiate(CannonBallPrefab);
            }
        }
    }

  
}
