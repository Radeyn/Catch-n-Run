using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyCollision : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rb;
    private bool damageTaken;
    

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        rb = GetComponent<Rigidbody2D>();
    }



    public bool DamageTaken(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            player.animator.SetTrigger("GetHit");

            player.playerHealth--;
            Destroy(gameObject);


            Debug.Log("Player Health: " + player.playerHealth);

            return true;
        }

        return false;
    }
}