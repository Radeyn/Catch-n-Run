using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    public event Action<float> OnScoreChanged;
    
    public float score = 0;
    
    public void AddScore(float amount)
    {
        score += amount;
        OnScoreChanged?.Invoke(score);
    }

    public float GetScore()
    {
        return score;
    }
}
