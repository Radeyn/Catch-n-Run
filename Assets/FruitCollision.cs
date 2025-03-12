using UnityEngine;

public class FruitCollision : MonoBehaviour
{
    private Player player;
    private Rigidbody2D rb;
    private int playerScore;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        playerScore = player.score;


        if (collision.gameObject.CompareTag("Player"))
        {
            player.score++;

            Destroy(gameObject); // Çarpışan Fruit objesini yok et
            Destroy(gameObject, 5);
            Debug.Log("Score: " + playerScore);

            

        }
    }

    public void DestroyFruit() 
    
    { 
        DestroyImmediate(gameObject); 
    }


}
