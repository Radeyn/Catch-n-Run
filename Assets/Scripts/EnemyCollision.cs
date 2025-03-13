using UnityEngine;
using UnityEngine.Audio;

public class EnemyCollision : MonoBehaviour
{
    private Player player;
    public Rigidbody2D rb;
    public AudioSource audioSource;


    private void Start()
         {
            player = FindAnyObjectByType<Player>();
            rb = GetComponent<Rigidbody2D>();
            audioSource = GetComponent<AudioSource>();

         }

   

        public void OnCollisionEnter2D(Collision2D collision)
    {



        if (collision.gameObject.CompareTag("Player"))
        {

            player.animator.SetTrigger("GetHit");

            player.playerHealth--;



            Debug.Log("Player Health: " + player.playerHealth);

        }
        audioSource.Play();
        
        Destroy(gameObject, 1f);



    }
}