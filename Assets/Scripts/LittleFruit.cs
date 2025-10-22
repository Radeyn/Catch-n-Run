﻿using UnityEngine;

public class LittleFruit : MonoBehaviour
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
        if (!collision.gameObject.CompareTag("Player")) return;
        _score.AddScore(20);
        Destroy(gameObject);
        
        if (!collision.gameObject.CompareTag("Enemy")) return;
        Destroy(gameObject);
    }

}
