using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private PlayerMovement _playerControl;
    
    [SerializeField] AudioSource damageSound;
    [SerializeField] AudioSource eatingSound;
    [SerializeField] AudioSource footstepsSound;
    private void Start()
    {
        _playerControl = GetComponent<PlayerMovement>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            damageSound.Play();
        }
        if (collision.gameObject.CompareTag("Fruit"))
        {
            eatingSound.Play();
        }
    }

    //private void update()
    //{
    //    walkingsfx();
    //}

    //private void walkingsfx()
    //{
    //    if (_playercontrol.ismoving)
    //    {
    //        if (!footstepssound.isplaying)
    //        {
    //            footstepssound.play();
    //        }
    //    }
    //    else
    //    {
    //        footstepssound.stop();

    //    }
    //}
}
