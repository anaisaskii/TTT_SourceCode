using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        animator.speed = 0;
    }

    void Update()
    {
        //Ensures animation only plays when player moves forward
        //Plays animation when up key is pressed down
        //Stops animation when key is key is up
        if (Input.GetKeyDown(KeyCode.W))
        {
            //sets PlayerActions parameter to 1
            //Conditions in animator specify that if PlayerActions equals 1, plays animation
            animator.SetInteger("PlayerActions", 1);
            animator.speed = 1;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            //sets PlayerActions parameter to 1
            //Conditions in animator specify that if PlayerActions equals 0, stops animation
            animator.SetInteger("PlayerActions", 0);
            animator.speed = 1;
        }
    }
}
