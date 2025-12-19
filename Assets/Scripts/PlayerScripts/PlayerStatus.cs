using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatus : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] int maxHealth = 4;
    private float CurrentSpeed;
    public int CurrentHealth { get; private set; }

    [Header("References")]
    [SerializeField] Animator animator;
    [SerializeField] GameDifficulty gameDifficulty;
    [SerializeField] InvulnerabilityFrames invulnerabilityFrames;
    
    
    public bool IsDead {get; private set;}
    
    private void Start()
    {
        CurrentHealth = maxHealth;
        
        Subscribe(gameDifficulty);
    }
    void Update()
    {
        KillChar();
    }
    private void Subscribe(GameDifficulty difficulty)
    {
        //difficulty.OnPlayerSpeedPenalty += LowerSpeed;
        //difficulty.OnScaleChange += IncreaseScale;
    }
   
    
    public void TakeDamage(int damage)
    {
        if (IsDead) return;
        
        CurrentHealth -= damage;
        animator.SetTrigger("GetHit");
        StartCoroutine(invulnerabilityFrames.IFramesStart());

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            IsDead = true;
        }

    }

    private void KillChar()
    {
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            CurrentHealth -= 4;
            IsDead = true;
        }
    }
    
    public void Heal(int health)
    {
        if (IsDead) return; // Cant heal if its dead

        CurrentHealth += health;
        if (CurrentHealth > maxHealth )
        {
            CurrentHealth = maxHealth;
        }
    }

    //private void LowerSpeed(float penalty)
    //{
    //    CurrentSpeed = Mathf.Max(minSpeed, CurrentSpeed - penalty);
    //    Debug.Log("Speed Decreased: " + CurrentSpeed);
    //}

    //private void IncreaseScale(float increaseScale)
    //{
    //    ScaleX = Mathf.Min(maxScaleX, ScaleX + increaseScale);
    //    Debug.Log("Scale Increased: " + ScaleX);
    //}
    
}
