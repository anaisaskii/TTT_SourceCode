using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuppliesSpawner : MonoBehaviour
{
    //stores last and next spawn times
    float LastSpawnTime = -500f;
    float NextSpawnTime = 3;

    public Object SuppliesPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //subtracts last spawn time from the time that the program has been running
        //Checks if it is bigger than the next spawn time
        if (Time.time - LastSpawnTime > NextSpawnTime)
        {
            NextSpawnTime = Random.Range(5, 10);
            LastSpawnTime = Time.time;
            Instantiate(SuppliesPrefab);
        }
    }
}
