using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Animation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>(); //Gets animator component
        animator.speed = 0; //Speed of animator
    }

    void Update()
    {
        //Ensures animation only plays when player moves forward
        //Plays animation when up key is pressed down
        //Stops animation when key is key is up
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //sets Player2Actions parameter to 1
            //Conditions in animator specify that if Player2Actions equals 1, plays animation
            animator.SetInteger("Player2Actions", 1); 
            animator.speed = 1;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            //sets Player2Actions parameter to 1
            //Conditions in animator specify that if Player2Actions equals 0, stops animation
            animator.SetInteger("Player2Actions", 0);
            animator.speed = 1;
        }
    }
}
