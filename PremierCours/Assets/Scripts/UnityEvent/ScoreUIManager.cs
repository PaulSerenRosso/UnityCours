using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        ScoreManager.OnScoreChange += RefreshScoreText;
    }

    void RefreshScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
}
