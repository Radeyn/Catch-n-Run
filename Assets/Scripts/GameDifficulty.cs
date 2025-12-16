using System;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] SpawnScript spawnScript;
    
    [SerializeField] private float speedPenalty = 1.5f;
    [SerializeField] private float decreaseSpawnInterval = 0.1f;
    [SerializeField] private float increaseScale = 0.3f;
    [SerializeField] private float speedMultiplier = 1f;
    
    
    private int nextThreshold = 200;
    
    public event Action<float> OnSpikeSpeedChange;
    public event Action<float> OnPlayerSpeedPenalty;
    public event Action<float> OnSpawnSpeedChange;
    public event Action<float> OnScaleChange;

    private void Start()
    {
        score.OnScoreChanged += HandleScoreChange;
    }

    private void HandleScoreChange(float currentScore)
    {
        if (currentScore >= nextThreshold)
        {
            IncreaseDifficulty();
            nextThreshold += 200;
        }
    }
    
    private void IncreaseDifficulty()
    {
        PlayerSpeedChange();
        SpikeSpeedChange();
        DecreaseSpawnInterval();
        PlayerScaleChange();
    }

    private void SpikeSpeedChange()
    {
        speedMultiplier += 0.1f;
        OnSpikeSpeedChange?.Invoke(speedMultiplier);
    }

    private void PlayerSpeedChange()
    {
        OnPlayerSpeedPenalty?.Invoke(speedPenalty);
    } 
    private void DecreaseSpawnInterval()
    {
        OnSpawnSpeedChange?.Invoke(decreaseSpawnInterval);
    }

    private void PlayerScaleChange()
    {
        OnScaleChange?.Invoke(increaseScale);
    }
    
}
