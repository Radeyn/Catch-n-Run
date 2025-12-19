using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatus : MonoBehaviour
{
    
    [SerializeField] int maxHealth = 4;
    
    [SerializeField] int maxSpeed = 25;
    [SerializeField] int minSpeed = 10;
    
    [SerializeField] Animator animator;
    
    [SerializeField]GameDifficulty gameDifficulty;
    
    
    public float ScaleX { get; private set; } = 1f;
    private float maxScaleX = 3f;
    public int CurrentHealth { get; private set; }
    [SerializeField] public float CurrentSpeed;
    
    public bool IsDead {get; private set;}
    
    private void Start()
    {
        CurrentHealth = maxHealth;
        CurrentSpeed =  maxSpeed;
        
        Subscribe(gameDifficulty);
    }
    void Update()
    {
        KillChar();
    }
    private void Subscribe(GameDifficulty difficulty)
    {
        difficulty.OnPlayerSpeedPenalty += LowerSpeed;
        difficulty.OnScaleChange += IncreaseScale;
    }
   
    
    public void TakeDamage(int damage)
    {
        if (IsDead) return;
        
        CurrentHealth -= damage;
        animator.SetTrigger("GetHit");
        
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

    private void LowerSpeed(float penalty)
    {
        CurrentSpeed = Mathf.Max(minSpeed, CurrentSpeed - penalty);
        Debug.Log("Speed Decreased: " + CurrentSpeed);
    }

    private void IncreaseScale(float increaseScale)
    {
        ScaleX = Mathf.Min(maxScaleX, ScaleX + increaseScale);
        Debug.Log("Scale Increased: " + ScaleX);
    }
    
}
