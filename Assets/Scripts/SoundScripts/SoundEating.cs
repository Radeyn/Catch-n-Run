using UnityEngine;

public class SoundEating : MonoBehaviour
{
    private PlayerControl _playerControl;
    public AudioSource eatingSound;
    private void Start()
    {
        _playerControl = FindAnyObjectByType<PlayerControl>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Fruit"))
        {

            eatingSound.Play();

        }
    }
}
