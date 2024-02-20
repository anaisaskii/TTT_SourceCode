using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinnerText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winnerText;

    private int P1Score = PlayerScore.Player1Score; //Stores Player 1's score
    private int P2Score = PlayerScore.Player2Score; //Stores Player 2's score

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checks which player has a higher score and displays it

        if (P1Score > P2Score) //P1 win
        {
            winnerText.text = "Winner: Player 1";
        }
        else if(P2Score > P1Score) //P2 win
        {
            winnerText.text = "Winner: Player 2";
        }
        else //Tie
        {
            winnerText.text = "Tie!";
        }
    }
}
