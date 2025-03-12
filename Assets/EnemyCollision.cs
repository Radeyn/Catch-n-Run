using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float playerHealth = player.playerHealth;


        if (collision.gameObject.CompareTag("Player"))
        {

            player.animator.SetTrigger("GetHit");

            player.playerHealth--;

            Destroy(gameObject);

            Debug.Log("Player Health: " + player.playerHealth);

            

        }
    }

    public void DestroyEnemy()
    {
        DestroyImmediate(gameObject);
    }
}