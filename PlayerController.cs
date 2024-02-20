using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed; //stores player's current speed

    public bool Player1; //checks whether current player is player 1 or 2

    private bool speedBoost = false; //stores whether player has a speedboost (by default does not)
    private bool speedReduce = false; //stores whether player has a speed reduction (by default does not)

    public Image P1Ink; //stores images for ink that covers screen when squid is hit (for player 1's side)
    public Image P2Ink; //same as above but for player 2's side

    //code below stores audio clips for all obstacles/powerups
    public AudioClip CoinCollect;
    AudioSource CoinSound;

    public AudioClip BarrelHit;
    AudioSource BarrelSound;

    public AudioClip SuppliesCollect;
    AudioSource SuppliesSound;

    public AudioClip WaveHit;
    AudioSource WaveSound;

    public AudioClip CannonBallHit;
    AudioSource CannonBallSound;

    public AudioClip SquidHit;
    AudioSource SquidSound;

    // Start is called before the first frame update
    void Start()
    {
        CoinSound = GetComponent<AudioSource>();
        BarrelSound = GetComponent<AudioSource>();
        SuppliesSound = GetComponent<AudioSource>();
        WaveSound = GetComponent<AudioSource>();
        CannonBallSound = GetComponent<AudioSource>();
        SquidSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1 == true) //if current player has 'Player 1' bool true (Player 1 movement)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            //uses input manager to take user inputs
            //takes input and transforms player by that amount
            //has -0.04 on speed for y so that boat is contantly moving downwards
            gameObject.transform.position = new Vector2(transform.position.x + (horizontal * speed), transform.position.y + (vertical * speed) - 0.04f);

            //Code to ensure that player stays within bounds
            //If player tries to go beyond boundries, they will be set back to the boundry edge
            if (transform.position.x <= -5.9f)
            {
                transform.position = new Vector2(-5.9f, transform.position.y);
            }
            else if (transform.position.x >= -2.00f)
            {
                transform.position = new Vector2(-2.00f, transform.position.y);
            }

            if (transform.position.y <= -4.00f)
            {
                transform.position = new Vector2(transform.position.x, -4.00f);
            }
            else if (transform.position.y >= 3.5f)
            {
                transform.position = new Vector2(transform.position.x, 3.5f);

            }
        }
        else //Player 2 Movement
        {
            float horizontal = Input.GetAxisRaw("Horizontal1");
            float vertical = Input.GetAxisRaw("Vertical1");

            //uses input manager to take user inputs
            //takes input and transforms player by that amount
            //has -0.04 on speed for y so that boat is contantly moving backwards
            gameObject.transform.position = new Vector2(transform.position.x + (horizontal * speed), transform.position.y + (vertical * speed) - 0.04f);

            if (transform.position.x <= 3.00f)
            {
                transform.position = new Vector2(3.00f, transform.position.y);
            }
            else if (transform.position.x >= 6.8f)
            {
                transform.position = new Vector2(6.8f, transform.position.y);
            }

            if (transform.position.y <= -4.00f)
            {
                transform.position = new Vector2(transform.position.x, -4.00f);
            }
            else if (transform.position.y >= 3.5f)
            {
                transform.position = new Vector2(transform.position.x, 3.5f);
            }
        }

        if (speedBoost == false && speedReduce == false) //if player does not have a speed boost or speed reduction effect
        {
            speed = 0.1f; //default speed is 0.1
        }
        else if(speedBoost == true) //if player has a speedboost
        {
            speed = 0.3f; //increased speed
        }
        else if(speedReduce == true) //if player has speed reduction effect
        {
            speed = 0.05f; //slower speed
        }

    }

    void OnTriggerEnter2D(Collider2D coll) //Code only runs when another object touches gameobjects collider
    {
        if (Player1 == true)
        {
            //Code below checks if player 1 touches object with specific tag
            //Plays appropriate sound and increases score accordingly

            if (coll.gameObject.tag == "Coin") 
            {
                CoinSound.PlayOneShot(CoinCollect, 10.0f); 
                PlayerScore.Player1Score += 1; 

            }

            if (coll.gameObject.tag == "Barrel")
            {
                BarrelSound.PlayOneShot(BarrelHit, 10.0f);
                PlayerScore.Player1Score -= 2; 

            }

            if (coll.gameObject.tag == "Supplies")
            {
                SuppliesSound.PlayOneShot(SuppliesCollect, 10.0f);
                PlayerScore.Player1Score += 5;

                speedBoost = true;
                StartCoroutine(speedBoostWait());
            }
            

            if (coll.gameObject.tag == "Squid")
            {
                PlayerScore.Player1Score -= 3;
                SquidSound.PlayOneShot(SquidHit, 10.0f);

                P1Ink.fillAmount = 1.0f;
                StartCoroutine(inkDisplayP1());

            }

            if (coll.gameObject.tag == "Wave")
            {
                PlayerScore.Player1Score -= 2;

                WaveSound.PlayOneShot(WaveHit, 10.0f);

                speedReduce = true;
                StartCoroutine(waveSpeedReduce());

            }

            if (coll.gameObject.tag == "CannonBall")
            {
                PlayerScore.Player1Score -= 1;

                CannonBallSound.PlayOneShot(CannonBallHit, 10.0f);

            }
        }
        else //Above code for player 2
        {
            Debug.Log("Player2 called");

            if (coll.gameObject.tag == "Coin")
            {
                CoinSound.PlayOneShot(CoinCollect, 10.0f);
                PlayerScore.Player2Score += 1;

            }

            if (coll.gameObject.tag == "Barrel")
            {
                BarrelSound.PlayOneShot(BarrelHit, 10.0f);
                PlayerScore.Player2Score -= 2;

            }

            if (coll.gameObject.tag == "Supplies")
            {
                SuppliesSound.PlayOneShot(SuppliesCollect, 10.0f);
                PlayerScore.Player2Score += 5;

                speedBoost = true;
                StartCoroutine(speedBoostWait());
            }

            if (coll.gameObject.tag == "Squid")
            {
                PlayerScore.Player2Score -= 3;
                SquidSound.PlayOneShot(SquidHit, 10.0f);

                P2Ink.fillAmount = 1.0f;
                StartCoroutine(inkDisplayP2());

            }

            if (coll.gameObject.tag == "Wave")
            {
                PlayerScore.Player2Score -= 2;

                WaveSound.PlayOneShot(WaveHit, 10.0f);

                speedReduce = true;
                StartCoroutine(waveSpeedReduce());

            }

            if (coll.gameObject.tag == "CannonBall")
            {
                PlayerScore.Player2Score -= 1;

                CannonBallSound.PlayOneShot(CannonBallHit, 10.0f);
            }
        }


        //used https://docs.unity3d.com/ScriptReference/WaitForSeconds.html to help with IEnumerators and WaitForSeconds
        IEnumerator inkDisplayP1()
        {
            yield return new WaitForSecondsRealtime(5.0f); //wait for 5 seconds
            P1Ink.fillAmount = 0.0f; //change visibility of Player 1's ink to 0
        }

        IEnumerator inkDisplayP2()
        {
            yield return new WaitForSecondsRealtime(5.0f); //wait for 5 seconds
            P2Ink.fillAmount = 0.0f; //change visibility of Player 2's ink to 0
        }

        IEnumerator speedBoostWait()
        {
            yield return new WaitForSecondsRealtime(5.0f); //wait for 5 seconds
            speedBoost = false; //removes speedboost
        }

        IEnumerator waveSpeedReduce()
        {
            yield return new WaitForSecondsRealtime(5.0f); //wait for 5 seconds
            speedReduce = false; //removes speed reduction
        }
    }

}
