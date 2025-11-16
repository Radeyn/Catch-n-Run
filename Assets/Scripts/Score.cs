using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    public event Action<int> OnScoreChanged;
    
    public  int score = 0;

    private void Start()
    {
    }

    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChanged?.Invoke(score);
    }

    public int GetScore()
    {
        return score;
    }
}
