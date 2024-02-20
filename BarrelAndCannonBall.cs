using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelAndCannonBall : MonoBehaviour
{


    public bool isBarrel; //bool to check whether obstacle is a barrel or not

    Rigidbody2D BarrelRB;
    Rigidbody2D CannonBallRB;

    // Start is called before the first frame update
    void Start()
    {
        
        BarrelRB = GetComponent<Rigidbody2D>();
        CannonBallRB = GetComponent<Rigidbody2D>();

        transform.position = new Vector2(Random.Range(-6, 7), 10);

        if (isBarrel == true) //checks if object is squid or wave
        {
            BarrelRB.AddForce(new Vector3(0, Random.Range(-150, -200))); //assigns force to object (how quick it will fall)
        }
        else
        {
            CannonBallRB.AddForce(new Vector3(0, Random.Range(-250, -400)));
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
        //Runs if obstacle is a barrel
        if (isBarrel == true)
        {
            if (coll.gameObject.tag == "Player") //if the barrel collides with the player it is destroyed
            {
                Destroy(gameObject); //destroy object
                Debug.Log("Barrel hit player");
            }

            if (coll.gameObject.tag == "Land") //if the barrel collides with the player it is destroyed
            {
                Destroy(gameObject);
            }
        }
        else //Runs if obstacle is a CannonBall
        {
            if (coll.gameObject.tag == "Player") //if the CannonBall collides with the player it is destroyed
            {
                Destroy(gameObject);
                Debug.Log("CannonBall hit player");

            }

            if (coll.gameObject.tag == "Land") //if the CannonBall collides with the player it is destroyed
            {
                Destroy(gameObject);
            }
        }
    }

}
