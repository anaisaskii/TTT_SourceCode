using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinSpawner : MonoBehaviour
{
    //Stores next and last spawntimes
    float LastSpawnTime = -500f; 
    float NextSpawnTime = 3;

    public Object CoinPrefab;
    public static int PlayerScore = 0; //Initiates player score and sets it to 0

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - LastSpawnTime > NextSpawnTime)
        {
            NextSpawnTime = Random.Range(1, 3);
            LastSpawnTime = Time.time;
            Instantiate(CoinPrefab); //Spawns coin
        }
    }

}
