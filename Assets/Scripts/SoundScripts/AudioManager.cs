using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private PlayerControl _playerControl;
    
    [SerializeField] AudioSource damageSound;
    [SerializeField] AudioSource eatingSound;
    [SerializeField] AudioSource footstepsSound;
    private void Start()
    {
        _playerControl = GetComponent<PlayerControl>();
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

    private void Update()
    {
        WalkingSound();
    }

    private void WalkingSound()
    {
        if (_playerControl.IsMoving())
        {
            if (!footstepsSound.isPlaying) 
            {
                footstepsSound.Play();
            }
        }else
        {
            footstepsSound.Stop();

        }
    }
}
