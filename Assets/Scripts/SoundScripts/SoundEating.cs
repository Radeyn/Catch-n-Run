using UnityEngine;

public class SoundEating : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    public AudioSource eatingSound;
    private void Start()
    {
        _playerMovement = FindAnyObjectByType<PlayerMovement>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Fruit"))
        {

            eatingSound.Play();

        }
    }
}
