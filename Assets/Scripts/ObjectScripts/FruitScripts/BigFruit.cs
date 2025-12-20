using UnityEngine;
using TMPro;

public class BigFruit : MonoBehaviour
{
    private Score _score;
    private PlayerStatus player;
    private Rigidbody2D _rigidbody2D;
    private int scoreValue = 50;
    [SerializeField] Color textColor;
    [SerializeField] GameObject floatingTextPrefab;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.angularVelocity = 200f;
        
    }
    
    public void SetReferences(Score score)
    {
        _score = score;
    }
    public void SetPlayer(PlayerStatus playerStatus)
    {
        player = playerStatus;
    }
    private void ShowFloatingText()
    {
        var text =  Instantiate(floatingTextPrefab, player.transform.position, Quaternion.identity);
        text.GetComponent<TextMeshPro>().text = "+" + scoreValue.ToString();
        text.GetComponent<TextMeshPro>().color = textColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _score.AddScore(scoreValue);
            ShowFloatingText();
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
