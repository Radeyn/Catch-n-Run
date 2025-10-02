using UnityEngine;

public class FruitCollision : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Score _score;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.angularVelocity = 200f;
        
    }
    
    public void SetReferences(Score score)
    {
        _score = score;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        _score.AddScore(1);
        Destroy(gameObject);
    }

}
