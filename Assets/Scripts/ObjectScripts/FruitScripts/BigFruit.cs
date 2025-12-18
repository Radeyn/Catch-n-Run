using UnityEngine;

public class BigFruit : MonoBehaviour
{
    private Score _score;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.angularVelocity = 200f;
        
    }
    
    public void SetReferences(Score score)
    {
        _score = score;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _score.AddScore(50);
            gameObject.SetActive(false);
            
        } 
        
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }

        else if (collision.gameObject.CompareTag("Floor"))
        {
            gameObject.SetActive(false);
        }
    }

}
