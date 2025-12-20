using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LittleFruit : MonoBehaviour
{
    private Score _score;
    private PlayerStatus player;
    private Rigidbody2D _rigidbody2D;
    private int scoreValue = 20;

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
            gameObject.SetActive(false);
            InstantiateFloatingText();

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
