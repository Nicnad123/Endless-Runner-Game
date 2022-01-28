using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI distanceTraveledText;
    public TextMeshProUGUI highScoreText;

    public void OnEnable()
    {
        finalScoreText.text = "Final Score: " + ScoreManager.score.ToString();
        distanceTraveledText.text = "Distance Traveled: " + PlayerController.distanceUnit.ToString();
        highScoreText.text = "HighScore: " + ScoreManager.highScore.ToString();
    }
}
