using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int player1Score = 0;
    private int player2Score = 0;

    public Text player1ScoreText;
    public Text player2ScoreText;

    public void Player1Goal()
    {
        player1Score++;
        print("Player1 Scores");
        player1ScoreText.text = player1Score.ToString();
    }

    public void Player2Goal()
    {
        player2Score++;
        print("Player2 Scores");
        player2ScoreText.text = player2Score.ToString();
    }
}
