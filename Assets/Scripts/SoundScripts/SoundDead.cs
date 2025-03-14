using UnityEngine;

public class SoundDead : MonoBehaviour
{
    private Player player;
    public AudioSource deadSound;
    private void Start()
    {
        player = FindAnyObjectByType<Player>();

    }


    public void IsDead()
    {

        if (deadSound != null)
        {
            deadSound.Play();

        }

    }


    public float GetSoundDuration()
    {
        return deadSound.clip.length;
    }
}
