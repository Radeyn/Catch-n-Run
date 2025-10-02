using UnityEngine;

public class SoundDamage : MonoBehaviour
{
    private PlayerControl _playerControl;
    public AudioSource damageSound;
    private void Start()
    {
        _playerControl = FindAnyObjectByType<PlayerControl>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
            {

            damageSound.Play();


    
            }
    }

 
}
