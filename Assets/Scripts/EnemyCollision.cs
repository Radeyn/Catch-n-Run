using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private PlayerStatus _playerStatus;
    
    public Rigidbody2D rb;
    
    

    private void Start()
    {
            rb = GetComponent<Rigidbody2D>();
    }

    public void SetReferences(PlayerStatus playerStatus)
    {
        _playerStatus = playerStatus;
    }
  

    public void UpdateSpikeGravity(float gravityScale)
    {
        rb.gravityScale = gravityScale;
    }


    private void OnCollisionEnter2D(Collision2D collision)
        {

        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (_playerStatus != null)
                _playerStatus.TakeDamage(1);
            
            Destroy(gameObject);

            Debug.Log("Player Health: " + _playerStatus.CurrentHealth);

        }

        }

    
}