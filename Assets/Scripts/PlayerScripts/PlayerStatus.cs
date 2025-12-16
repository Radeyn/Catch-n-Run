using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private int maxHealth = 4;
    [SerializeField] private int maxSpeed = 25;
    public float ScaleX = 1f;
    
    public Animator animator;
    public int CurrentHealth { get; private set; }
    public float CurrentSpeed {get; private set;}
    
    public bool _isDead {get; private set;}
    private void Start()
    {
        CurrentHealth = maxHealth;
        CurrentSpeed =  maxSpeed;
    }
    public void TakeDamage(int damage)
    {
        if  (_isDead) return;
        
        CurrentHealth -= damage;
        animator.SetTrigger("GetHit");
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            _isDead = true;
        }
    }
    
    public void Heal(int health)
    {
        if (_isDead) return; // Cant heal if its dead

        CurrentHealth += health;
        if (CurrentHealth > maxHealth )
        {
            CurrentHealth = maxHealth;
        }
    }

    
}
