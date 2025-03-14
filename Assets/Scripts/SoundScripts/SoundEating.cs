using UnityEngine;

public class SoundEating : MonoBehaviour
{
    private Player player;
    public AudioSource eatingSound;
    private void Start()
    {
        player = FindAnyObjectByType<Player>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Fruit"))
        {

            eatingSound.Play();

        }
    }
}
