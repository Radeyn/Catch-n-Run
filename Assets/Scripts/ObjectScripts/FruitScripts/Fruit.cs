using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private Score _score;
    private PlayerStatus player;
    private Rigidbody2D _rigidbody2D;
    private FruitPool _fruitSpawner;
    private int scoreValue = 40;

    
    [SerializeField] GameObject floatingTextPrefab;
    [SerializeField] Color textColor;

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

    public void SetFruit(FruitPool fruitSpawner)
    {
        _fruitSpawner = fruitSpawner;
    }

    private void InstantiateFloatingText()
    {
        var text = Instantiate(floatingTextPrefab, player.transform.position, Quaternion.identity);

        text.GetComponent<TextMeshPro>().text = "+" + scoreValue.ToString();
        text.GetComponent<TextMeshPro>().color = textColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _score.AddScore(scoreValue);
            _fruitSpawner._fruitObjectPool.Release(this);
            InstantiateFloatingText();

        } 
        
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            _fruitSpawner._fruitObjectPool.Release(this);
        }

        else if (collision.gameObject.CompareTag("Floor"))
        {
            _fruitSpawner._fruitObjectPool.Release(this);
        }
    } 
}
