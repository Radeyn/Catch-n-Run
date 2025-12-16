using System;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private float speedPenalty = 1.5f;
    [SerializeField] SpawnScript spawnScript;
    private int nextThreshold = 200;
    public float speedMultiplier { get; private set; } = 1;
    
    public event Action<float> OnSpikeSpeedChange;
    public event Action<float> OnPlayerSpeedPenalty;

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
        PlayerSpeedChange();
        SpikeSpeedChange();
        
        Debug.Log("Spawn Increased");    
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
    
}
