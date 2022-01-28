using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI endScoreText;

    public static int score = 0;
    public static int highScore = 0;

    private void Awake()
    {
        instance = this;
        score = 0;
    }

    void Start()    
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        scoreText.text = "Points: " + score.ToString();
        highscoreText.text = "Highscore: " + highScore.ToString();
        endScoreText.text = "Final Score: " + score.ToString();
    }

    public void AddPoint()
    {
        score++;
        scoreText.text = "Points: " + score.ToString();
        if(highScore < score)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
        
    }
}
