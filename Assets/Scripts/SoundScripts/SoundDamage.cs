using UnityEngine;

public class SoundDamage : MonoBehaviour
{
    private Player player;
    public AudioSource damageSound;
    private void Start()
    {
        player = FindAnyObjectByType<Player>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
            {

            damageSound.Play();


    
            }
    }

 
}
