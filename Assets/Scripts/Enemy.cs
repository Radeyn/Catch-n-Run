using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private GameDifficulty _gameDifficulty;
    PlayerStatus _playerStatus;
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
    public void SetDifficulty(GameDifficulty gameDifficulty)
    {
        _gameDifficulty = gameDifficulty;
        
        _gameDifficulty.OnSpeedChange += UpdateSpikeGravity;
         UpdateSpikeGravity(_gameDifficulty.speedMultiplier);
    }

    private void UpdateSpikeGravity(float speedMultiplier)
    {
        _rigidbody.gravityScale = baseGravity * speedMultiplier;
        
    }
    
    private void OnDisable()
    {
        if (_gameDifficulty != null)
            _gameDifficulty.OnSpeedChange -= UpdateSpikeGravity;
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


   
}