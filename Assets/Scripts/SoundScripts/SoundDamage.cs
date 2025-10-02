using UnityEngine;

public class SoundDamage : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    public AudioSource damageSound;
    private void Start()
    {
        _playerMovement = FindAnyObjectByType<PlayerMovement>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
            {

            damageSound.Play();


    
            }
    }

 
}
