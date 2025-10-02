using UnityEngine;

public class SoundFootsteps : MonoBehaviour
{
    public AudioSource footstepsSound;
    private PlayerMovement _playerMovement;


    private void Start()
    {
        _playerMovement = FindAnyObjectByType<PlayerMovement>();
    }

    private void Update()
    {
        if (_playerMovement.IsMoving())
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
