using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidAndWave : MonoBehaviour
{
    public bool isSquid; //set if object is wave or squid

    Rigidbody2D SquidRB;
    Rigidbody2D WaveRB;

    // Start is called before the first frame update
    void Start()
    {

        SquidRB = GetComponent<Rigidbody2D>(); 
        WaveRB = GetComponent<Rigidbody2D>();

        transform.position = new Vector2(Random.Range(-6, 7), 10); //sets starting position for object

        if(isSquid == true) //checks if object is squid or wave
        {
            SquidRB.AddForce(new Vector3(0, Random.Range(-150, -300))); //assigns force to object (how quick it will fall)
        }
        else
        {
            WaveRB.AddForce(new Vector3(0, Random.Range(-100, -200)));
        }
       

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(isSquid == true)
        {
            if (coll.gameObject.tag == "Player") //if the squid collides with the player it is destroyed
            {
                Destroy(gameObject); //destroy object
            }

            if (coll.gameObject.tag == "Land") //if the squid touches the collider at the top of screen (tagged with land) it will be destroyed
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (coll.gameObject.tag == "Player") //if the Wavw collides with the player it is destroyed
            {
                Destroy(gameObject);

            }

            if (coll.gameObject.tag == "Land") //if the Wave touches the collider at the top of screen (tagged with land) it will be destroyed
            {
                Destroy(gameObject);
            }
        }


    }
}
