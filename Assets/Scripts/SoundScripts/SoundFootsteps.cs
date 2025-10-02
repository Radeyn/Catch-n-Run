using UnityEngine;

public class SoundFootsteps : MonoBehaviour
{
    public AudioSource footstepsSound;
    private PlayerControl _playerControl;


    private void Start()
    {
        _playerControl = FindAnyObjectByType<PlayerControl>();
    }

    private void Update()
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
