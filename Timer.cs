using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private float timeRemaning = 60.0f; //Sets amount of time per game

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //sets text for the timer text
        //each frame sets the total amount of time remaining to be minus, and equal, to the amount of time passed each frame
        //uses ToString to keep at 2 significant digure
        timerText.text = "Timer: " + (timeRemaning -= Time.deltaTime).ToString("F1"); 

        if (timeRemaning < 0) //If timer reaches 0
        {
            Application.LoadLevel(2); //Loads ending screen (Scene 2)
        }

    }
}
