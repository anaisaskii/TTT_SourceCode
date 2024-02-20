using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Coin sound effects
    public AudioClip CoinCollect;
    AudioSource CoinSound;


    Rigidbody2D CoinRB;

    // Start is called before the first frame update
    void Start()
    {
        CoinSound = GetComponent<AudioSource>();

        CoinRB = GetComponent<Rigidbody2D>();

        transform.position = new Vector2(Random.Range(-6, 7), 10); //Sets starting position for Coin
        CoinRB.AddForce(new Vector3(0, Random.Range(-150, -300))); //Adds force to Coin (How fast it will fall)
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnBecameInvisible() //Called when not visible on screen
    {
        Destroy(gameObject); //Destroys gameobject when not on screen
    }

    void OnTriggerEnter2D(Collider2D coll) //Only called when Coin collides with an object
    {
        //Checks if Coin has collided with 'Player' or 'Land' tag and destroys object if so
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (coll.gameObject.tag == "Land")
        {
            Destroy(gameObject);
        }
    }
}
