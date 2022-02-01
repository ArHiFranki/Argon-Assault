using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        DisplayScore();
    }

    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.text = score.ToString();
    }
}
