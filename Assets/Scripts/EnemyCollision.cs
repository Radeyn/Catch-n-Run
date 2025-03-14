using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private Player player;
    public Rigidbody2D rb;


    private void Start()
    {
            player = FindAnyObjectByType<Player>();
            rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //rb = GetComponent<Rigidbody2D>();

    }

    public void UpdateSpikeGravity(float gravityScale)
    {
        rb.gravityScale = gravityScale;
    }


    private void OnCollisionEnter2D(Collision2D collision)
        {

        if (collision.gameObject.CompareTag("Player"))
           {

             player.animator.SetTrigger("GetHit");

             player.playerHealth--;


             Destroy(gameObject);

             Debug.Log("Player Health: " + player.playerHealth);

            }

        }
}