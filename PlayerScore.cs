using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public bool Player1; //Determines which sprite is player1/player2

    //Stores Player 1 and 2's score
    public static int Player1Score = 0; 
    public static int Player2Score = 0;

    //Score text for both players
    [SerializeField] TextMeshProUGUI scoreTextP1;
    [SerializeField] TextMeshProUGUI scoreTextP2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checks whether each player has 'Player1' as true amnd increases scores accordingly
        if(Player1 == true)
        {
            scoreTextP1.text = "Score: " + Player1Score;
        }
        else
        {
            scoreTextP2.text = "Score: " + Player2Score;
        }
    }
}
