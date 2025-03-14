using UnityEngine;

public class SoundFootsteps : MonoBehaviour
{
    public AudioSource footstepsSound;
    private Player player;


    private void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    private void Update()
    {
        if (player.IsMoving())
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
