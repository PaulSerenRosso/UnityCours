using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static event Action<int> OnScoreChange;

    public static ScoreManager instance;
    private void Awake()
    {
        instance = this;
    }

    private int score;

    public int Score
    {
        get => score;
        set
        {
            score = value;
            OnScoreChange?.Invoke(score);
        } 
            
    }
    
}
