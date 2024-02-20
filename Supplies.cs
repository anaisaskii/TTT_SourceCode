using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supplies : MonoBehaviour
{
    public Camera GameCamera;
    Rigidbody2D SuppliesRB;

    // Start is called before the first frame update
    void Start()
    {
        SuppliesRB = GetComponent<Rigidbody2D>();

        transform.position = new Vector2(Random.Range(-6, 7), 10); //Sets starting position for Supplies
        SuppliesRB.AddForce(new Vector3(0, Random.Range(-150, -300))); //Adds force to Supplies (How fast it will fall)

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible() //Called when object is no longer on screen
    {
        Destroy(gameObject); //Destroys Object
    }

    void OnTriggerEnter2D(Collider2D coll) //Only called when Supplies collides with an object
    {
        //Checks if Supplies has collided with 'Player' or 'Land' tag and destroys object if so
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            CoinSpawner.PlayerScore += 5;
        }

        if (coll.gameObject.tag == "Land")
        {
            Destroy(gameObject);
        }
    }
}
