using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameDifficulty gameDifficulty;
    private PlayerStatus _playerStatus;
    private Rigidbody2D _rigidbody;
    private float baseGravity= 1f;
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    public void SetPlayer(PlayerStatus playerStatus)
    {
        _playerStatus = playerStatus;
    }
    
    public void SetDifficulty(GameDifficulty difficulty)
    {
        gameDifficulty = difficulty;
        difficulty.OnSpikeSpeedChange += UpdateSpikeGravity;
        
    }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (_playerStatus != null)
                    _playerStatus.TakeDamage(1);
                
                gameObject.SetActive(false);

                Debug.Log("Player Health: " + _playerStatus.CurrentHealth);
            }
            
            else if (collision.gameObject.CompareTag("Floor"))
            {
                gameObject.SetActive(false);
            }

        }
    private void UpdateSpikeGravity(float decreaseSpawnInterval)
        {
            _rigidbody.gravityScale = baseGravity * decreaseSpawnInterval;
            Debug.Log("Gravity Scale: " + _rigidbody.gravityScale);
        }

   
}