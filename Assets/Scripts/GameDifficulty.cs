using System;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private SpawnScript spawnScript;
    
    private int nextThreshold = 200;
    public float speedMultiplier = 1;
    
    public event Action<float> OnSpeedChange;

    private void Start()
    {
        score.OnScoreChanged += HandleScoreChange;
    }

    private void HandleScoreChange(int currentScore)
    {
        if (currentScore >= nextThreshold)
        {
            IncreaseDiffucilty();
            nextThreshold += 200;
        }
    }

    private void IncreaseDiffucilty()
    {
        spawnScript.DecreaseSpawnInterval(0.1f);
        SpeedChange();
        
        Debug.Log("Spawn Increased");    
    }

    private void SpeedChange()
    {
        speedMultiplier += 0.1f;
        OnSpeedChange?.Invoke(speedMultiplier);
        
        
    }
    
}
